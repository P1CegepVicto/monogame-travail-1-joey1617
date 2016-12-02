using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tableau = new int[100];
            int moyenne = 0;
            Random rng = new Random();

            Console.WriteLine("Tableau: ");
            for (int i = 0; i <= 99; i++)
            {
                tableau[i] = rng.Next(-1, 100);
                moyenne += tableau[i];
                Console.Write(tableau[i] + " ||");
            }

            Console.WriteLine("\n");
            moyenne = moyenne / 100;
            Console.WriteLine("Indices: ");
            for (int i = 0; i <= 99; i++)
            {
                if (tableau[i] > moyenne)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(tableau[i] + " ||");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Moyenne =" + moyenne);
            Console.ReadLine();
        }
    }
}
