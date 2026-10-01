using System.Data;
using SQLiteDemo;

// ----------------------------------------------------------------------
// CONSULTAS SQL: viven aquí, en el programa, y se pasan al DataBaseManager
// ----------------------------------------------------------------------
const string SQL_CREAR_TABLA = @"
    CREATE TABLE IF NOT EXISTS Alumnos (
        Id        INTEGER PRIMARY KEY AUTOINCREMENT,
        Nombre    TEXT    NOT NULL,
        Apellidos TEXT    NOT NULL,
        Edad      INTEGER NOT NULL,
        Email     TEXT
    );";

const string SQL_INSERTAR = @"
    INSERT INTO Alumnos (Nombre, Apellidos, Edad, Email)
    VALUES (@nombre, @apellidos, @edad, @email);
    SELECT last_insert_rowid();";

const string SQL_LISTAR = "SELECT * FROM Alumnos ORDER BY Apellidos, Nombre;";

const string SQL_POR_ID = "SELECT * FROM Alumnos WHERE Id = @id;";

const string SQL_BUSCAR = @"
    SELECT * FROM Alumnos
    WHERE Nombre LIKE @texto OR Apellidos LIKE @texto;";

const string SQL_ACTUALIZAR = @"
    UPDATE Alumnos
    SET Nombre = @nombre, Apellidos = @apellidos, Edad = @edad, Email = @email
    WHERE Id = @id;";

const string SQL_ELIMINAR = "DELETE FROM Alumnos WHERE Id = @id;";

// ----------------------------------------------------------------------
// PROGRAMA PRINCIPAL
// ----------------------------------------------------------------------

// La base de datos se crea junto al ejecutable (bin\Debug\net10.0\escuela.db)
string ruta = Path.Combine(AppContext.BaseDirectory, "escuela.db");

using var db = new DataBaseManager(ruta);
db.EjecutarNonQuery(SQL_CREAR_TABLA);

bool salir = false;
while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("=== GESTIÓN DE ALUMNOS (SQLite) ===");
    Console.WriteLine("1. Listar alumnos");
    Console.WriteLine("2. Añadir alumno");
    Console.WriteLine("3. Buscar por Id");
    Console.WriteLine("4. Buscar por nombre o apellidos");
    Console.WriteLine("5. Modificar alumno");
    Console.WriteLine("6. Eliminar alumno");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    switch (Console.ReadLine())
    {
        case "1":
            MostrarTabla(db.EjecutarConsulta(SQL_LISTAR));
            break;

        case "2":
            var datosNuevo = PedirDatos();
            var idNuevo = db.EjecutarEscalar(SQL_INSERTAR, datosNuevo);
            Console.WriteLine($"Alumno insertado con Id {idNuevo}.");
            break;

        case "3":
            var porId = new Dictionary<string, object?> { ["@id"] = PedirEntero("Id: ") };
            MostrarTabla(db.EjecutarConsulta(SQL_POR_ID, porId));
            break;

        case "4":
            Console.Write("Texto a buscar: ");
            var busqueda = new Dictionary<string, object?> { ["@texto"] = $"%{Console.ReadLine()}%" };
            MostrarTabla(db.EjecutarConsulta(SQL_BUSCAR, busqueda));
            break;

        case "5":
            int idModificar = PedirEntero("Id a modificar: ");
            var existe = db.EjecutarConsulta(SQL_POR_ID, new Dictionary<string, object?> { ["@id"] = idModificar });
            if (existe.Rows.Count == 0) { Console.WriteLine("No existe ese Id."); break; }

            var datosModificar = PedirDatos();
            datosModificar["@id"] = idModificar;
            int modificadas = db.EjecutarNonQuery(SQL_ACTUALIZAR, datosModificar);
            Console.WriteLine(modificadas > 0 ? "Modificado." : "No se pudo modificar.");
            break;

        case "6":
            var paramEliminar = new Dictionary<string, object?> { ["@id"] = PedirEntero("Id a eliminar: ") };
            int eliminadas = db.EjecutarNonQuery(SQL_ELIMINAR, paramEliminar);
            Console.WriteLine(eliminadas > 0 ? "Eliminado." : "No existe ese Id.");
            break;

        case "0":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

// ----------------------------------------------------------------------
// Funciones auxiliares de consola
// ----------------------------------------------------------------------

// Pide los datos por consola y los devuelve como diccionario de parámetros SQL
static Dictionary<string, object?> PedirDatos()
{
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";
    Console.Write("Apellidos: ");
    string apellidos = Console.ReadLine() ?? "";
    int edad = PedirEntero("Edad: ");
    Console.Write("Email (vacío si no tiene): ");
    string? email = Console.ReadLine();

    return new Dictionary<string, object?>
    {
        ["@nombre"] = nombre,
        ["@apellidos"] = apellidos,
        ["@edad"] = edad,
        ["@email"] = string.IsNullOrWhiteSpace(email) ? null : email
    };
}

static int PedirEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int valor)) return valor;
        Console.WriteLine("Introduce un número entero válido.");
    }
}

static void MostrarTabla(DataTable tabla)
{
    if (tabla.Rows.Count == 0)
    {
        Console.WriteLine("Sin resultados.");
        return;
    }

    foreach (DataRow fila in tabla.Rows)
    {
        Console.WriteLine($"[{fila["Id"]}] {fila["Nombre"]} {fila["Apellidos"]} - {fila["Edad"]} años - " +
                          $"{(fila["Email"] == DBNull.Value ? "(sin email)" : fila["Email"])}");
    }
}
