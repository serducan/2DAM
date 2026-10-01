using System;
using System.Security.Cryptography.X509Certificates;
class Coche
{
    static void Main(String[] Args)
    {

        String Marca;
        String Modelo;
        int Velocidad;


        Acelerar();
        Frenar();
    }
        public Coche(string Marca, String Modelo, int Velocidad){

        Marca = Marca;
        Modelo = Modelo;
        Velocidad = Velocidad;

    }

    private static void Frenar()
    {
        
    }

    private static void Acelerar(){


        Console.WriteLine("Introduce un numero");
        int numero1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce tu numero2");
        int numero2 = Convert.ToInt32(Console.ReadLine());

        int resultadoSuma = numero1 + numero2;

        Console.WriteLine("El resultado de la suma es: " + resultadoSuma);


    }

    public String Marca { get ; set;  }




}

