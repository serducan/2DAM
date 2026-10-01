using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

//Crea una lista<int> de numeros enteros. Añade algunos elementos. Ordenalos de menor a mayor y muestrálos por pantalla
//Los elementos de la lista deben ser añadidos haciendo uso de la función Random

namespace HolaMundo
{
    internal class lista
    {
        public static void main(string[] args)
        {

            List<int> lista = new List<int>();
            Random rnd = new Random();

            Console.WriteLine("Cuantos numeros quieres introducir");

            int cantidadNumeros = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < cantidadNumeros; i++)
            {
                int numero = rnd.Next(1, 100);
                lista.Add(numero);

            }
            Console.WriteLine("Lista sin ordenar");
            foreach (int numero in lista)
            {

                Console.WriteLine(numero);

            }

            lista.Sort();

            Console.WriteLine("Lista Ordenada: ");
            foreach (int numero in lista)
            {

                Console.WriteLine(numero);

            }



        }

    }

}