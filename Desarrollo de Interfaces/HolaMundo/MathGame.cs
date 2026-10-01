using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HolaMundo
{
    internal class MathGame
    {

       
        public void main(string[] args)
        {
            List<int> lista = new List<int>();

            
            int opcion;

            do
            {
                Console.WriteLine("Bienvenido al adivinador de operaciones, selecciona una de la opciones: ");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicacion");
                Console.WriteLine("4. Division");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Suma();
                        break;
                    case 2:
                        Console.WriteLine($"La hora actual es: {DateTime.Now.ToShortTimeString()}\n");
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...\n");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.\n");
                        break;
                }
            } while (opcion != 3);
        }

        public void Suma()
        {
            Random rnd = new Random();

            int numero1 = rnd.Next(1, 100);
            int numero2 = rnd.Next(1, 100);

            Console.WriteLine($"{numero1} {numero2}");


            int respuesta = numero1 + numero2;


        }



    }

}
