using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo
{
    internal class Calculo
    {

        public static void main(String [] args)
        {

            Calcular();

        }

        private static void Calcular()
        {

            float altura, base1, radio, area;

            Console.WriteLine("Que operacion quieres realizar");
            Console.WriteLine("1. Calcular Area de un Circulo");
            Console.WriteLine("2. Calcular Area de un Rectángulo");
            Console.WriteLine("3. Calcular Area de un Triángulo");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {

                default:

                    Console.WriteLine("Has introducido una opcion incorrecta");

                    break;

                case 1:

                    Console.WriteLine("Dime el radio del circulo");
                    radio = Convert.ToInt32(Console.ReadLine());

                    area = (float)Math.PI * radio * 2;

                    Console.WriteLine("El area del circulo es " + area);

                    break;

                case 2:

              
                    Console.WriteLine("Dime la altura del triangulo");
                    altura = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Dime la base del triangulo");
                    base1 = Convert.ToInt32(Console.ReadLine());

                    area = (base1 * altura) / 2;

                    Console.WriteLine("El area del triágulo es " +  area);

                    break;

                case 3:


                    Console.WriteLine("Dime la altura del rectángulo");
                    altura = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Dime la base del rectángulo");
                    base1 = Convert.ToInt32(Console.ReadLine());

                    area = (base1 * altura) / 2;

                    Console.WriteLine("El area del rectángulo es " + area);


                    break;

            }





        }
    }
}
