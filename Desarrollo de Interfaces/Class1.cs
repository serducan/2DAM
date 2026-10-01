using System;
using System.Security.Cryptography.X509Certificates;

class Area
{

    float altura;
    float base1;
    float pi;

     static void main(string[] args)
    {

        Calcular();

    }
	

}

public void Calcular()
{


    Console.WriteLine("Que operacion quieres hacer");
    Console.WriteLine("1.Calcular circulo");
    Console.WriteLine("2.Calcular triágulo");
    Console.WriteLine("3.Calcular rectángulo");

    int opcion = Convert.toInt32(Console.ReadLine());

    switch (opcion)
    {
        default:

        case 1:
            Console.WriteLine("Dame su altura");
            float altura = Convert.



    }


}
