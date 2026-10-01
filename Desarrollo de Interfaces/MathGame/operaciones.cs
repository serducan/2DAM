using System;

namespace HolaMundo
{
    internal partial class MathGame
    {
        public static void Suma()
        {
            Random rnd = new Random();

            int numero1 = rnd.Next(1, 100);
            int numero2 = rnd.Next(1, 100);


            Console.WriteLine($"Adivina la suma de {numero1} + {numero2} = ");
            int respuesta = LeerEntero();

            int resultado = numero1 + numero2;

            if (respuesta != resultado)
            {
                Console.WriteLine("Has fallado");
            }
            else
            {
                Console.WriteLine("Has acertado, has ganado un punto");
                contador++;
                Console.WriteLine($"Tienes: {contador} punto/s");
            }
        }

        public static void Resta()
        {
            Random rnd = new Random();

            int numero1 = rnd.Next(1, 100);
            int numero2 = rnd.Next(1, 100);


            Console.WriteLine($"Adivina la resta de {numero1} - {numero2} = ");
            int respuesta = LeerEntero();

            int resultado = numero1 - numero2;

            if (respuesta != resultado)
            {
                Console.WriteLine("Has fallado");
            }
            else
            {
                Console.WriteLine("Has acertado, has ganado un punto");
                contador++;
                Console.WriteLine($"Tienes: {contador} punto/s");
            }
        }

        public static void Multiplicacion()
        {
            Random rnd = new Random();

            int numero1 = rnd.Next(1, 100);
            int numero2 = rnd.Next(1, 100);


            Console.WriteLine($"Adivina la multiplicacion de {numero1} * {numero2} = ");
            int respuesta = LeerEntero();

            int resultado = numero1 * numero2;

            if (respuesta != resultado)
            {
                Console.WriteLine("Has fallado");
            }
            else
            {
                Console.WriteLine("Has acertado, has ganado un punto");
                contador++;
                Console.WriteLine($"Tienes: {contador} punto/s");
            }
        }

        public static void Division()
        {
            Random rnd = new Random();

            // Generamos primero el divisor y el resultado que queremos (cociente),
            // y calculamos el dividendo a partir de ellos.
            // Asi garantizamos que sea una division exacta (sin resto) y dividendo entre 0 y 100,
            // en vez de generar dos numeros al azar y dividirlos (lo que casi siempre da resto)
            int divisor = rnd.Next(1, 11);
            int cociente = rnd.Next(0, (100 / divisor) + 1);
            int dividendo = divisor * cociente;

            Console.WriteLine($"Adivina la division de {dividendo} / {divisor} = ");
            int respuesta = LeerEntero();

            if (respuesta != cociente)
            {
                Console.WriteLine("Has fallado");
            }
            else
            {
                Console.WriteLine("Has acertado, has ganado un punto");
                contador++;
                Console.WriteLine($"Tienes: {contador} punto/s");
            }
        }
    }
}