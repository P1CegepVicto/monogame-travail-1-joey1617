using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nombre;
            int nombreT = 0;

            Console.WriteLine("Quel est votre nombre");
            nombre = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            
                if (nombre % 2 == 0)
                {
                    while (nombre > 0)
                    {
                        nombreT += nombre;
                    Console.WriteLine(nombre);
                        nombre -= 2;
                    }
                }

                else
                while (nombre > 0)
                {
                    nombreT += nombre;
                    Console.WriteLine(nombre);
                    nombre -= 2;
                }

            Console.WriteLine("Total = " + nombreT);
            Console.ReadLine();
        }
    }
}
