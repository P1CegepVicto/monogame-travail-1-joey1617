using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen3
{
    class Program
    {
        static void Main(string[] args)
        {
            int moyenne;
            int total = 0;
            Random rng = new Random();

            int[] tableauAleatoire = new int[100];

            for (int i = 0 + 1; i <= 10; i++)
            {
               
                Console.WriteLine(" ");
                moyenne = total / 100;

                for (int l = 0 + 1; l <= 10; l++)
                {
                    tableauAleatoire[i] = rng.Next(1, 100);
                    
                    if (tableauAleatoire[i] > moyenne)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(tableauAleatoire[i] + " ||");
                        Console.ForegroundColor = ConsoleColor.White;
                        total += tableauAleatoire[i]++;
                    }

                    if (tableauAleatoire[i] <= moyenne)
                    {
                        Console.Write(tableauAleatoire[i] + " ||");
                        total += tableauAleatoire[i]++;
                    }
                }
                
            }

            moyenne = total / 100;
            Console.WriteLine(" \n");
            Console.WriteLine("Moyenne: " + moyenne);
            Console.ReadLine();
            }
    }
}
