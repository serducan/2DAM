using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HolaMundo
{
    internal partial class MathGame
    {
        static int contador;      // puntos: se incrementa en cada operacion cuando el usuario acierta
        static int preguntas;     // cuenta las preguntas respondidas en el juego actual (acierte o falle)
        static List<string> historial = new List<string>(); // Guarda cada partida

        public static void Main(string[] args)
        {

            int opcion;

            do
            {
                Console.WriteLine("Bienvenido al adivinador de operaciones, selecciona una de la opciones: ");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicacion");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Ver historial de juegos");
                Console.WriteLine("0. Salir");

                opcion = LeerEntero();

                switch (opcion)
                {
                    case 1:
                        Suma();
                        break;
                    case 2:
                        Resta();
                        break;
                    case 3:
                        Multiplicacion();
                        break;
                    case 4:
                        Division();
                        break;
                    case 5:
                        VerHistorial();
                        break;
                    case 0:
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

                // Solo se cuenta como "pregunta" si el usuario elige una de las operaciones (1 a 4),
                // no si eligio ver el historial o salir
                if (opcion >= 1 && opcion <= 4)
                {
                    preguntas++;
                    
                    // El juego hace 5 preguntas si llega termina la partida y la guarda en el historial
                    if (preguntas >= 5)
                    {
                        historial.Add($"Juego {historial.Count + 1}: {contador}/{preguntas} aciertos");
                        Console.WriteLine($"Fin del juego. Resultado: {contador}/{preguntas} aciertos");

                        // Reinicia para que se pueda jugar otro juego sin tener que cerrar el programa
                        contador = 0;
                        preguntas = 0;
                    }
                }

            } while (opcion != 0); // solo se sale del programa eligiendo 0
        }

        // Opcion del menu para consultar los juegos pasados
        static void VerHistorial()
        {
            if (historial.Count == 0)
            {
                Console.WriteLine("Todavia no hay juegos anteriores");
                return;
            }

            Console.WriteLine("Historial de juegos:");
            foreach (string juego in historial)
            {
                Console.WriteLine(juego);
            }
        }

        // Evita que el programa se rompa si el usuario escribe un texto en vez de un numero
        public static int LeerEntero()
        {
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Eso no es un numero, introduce un numero entero");
            }
            return numero;
        }
    }
}