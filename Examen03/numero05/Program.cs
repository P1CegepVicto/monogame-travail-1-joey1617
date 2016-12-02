using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numero05
{
    class Program
    {
        static void AffichageEntier()
        {
            int position = 0;
            bool[] Tableau = new bool[100];
            Random rng = new Random();

            for (int i = 0; i <= 99; i++)
            {
                if (rng.Next(0, 2) == 1)
                {
                    Tableau[i] = true;

                }
                if (rng.Next(0, 2) == 2)
                {
                    Tableau[i] = false;
                }
            }

            for (int i = position; i <= position + 9; i++)
            {

                if (Tableau[i] == false)
                {
                    Console.WriteLine(" ");
                    Console.Write(" Faux ||");
                }
                if (Tableau[i] == true)
                {
                    Console.WriteLine(" ");
                    Console.Write(" Vrai ||");
                }

                for (int l = position; l <= position + 8; l++)
                {
                    if (Tableau[i] == false)
                    {
                        Console.Write(" Faux ||");
                    }
                    if (Tableau[i] == true)
                    {
                        Console.Write(" Vrai ||");
                    }

                }
            }

        }

        static void Affichage10()
        {
            int position = 0;
            bool[] Tableau = new bool[100];
            Random rng = new Random();

            for (int i = 0; i <= 99; i++)
            {
                if (rng.Next(0, 2) == 1)
                {
                    Tableau[i] = true;

                }
                if (rng.Next(0, 2) == 2)
                {
                    Tableau[i] = false;
                }
            }


            for (int i = position; i <= position + 9; i++)
            {
                Console.Write(Tableau[i] + " || ");
            }
            Console.WriteLine("\n");



        }


        static void Main(string[] args)
        {
            bool[] Tableau = new bool[100];
            Random rng = new Random();
            string app = "w";
            string touche;
            int lost = 0;
            int position = 0;
            int essai = 0;

            for (int i = 0; i <= 99; i++)
            {
                if (rng.Next(0, 2) == 1)
                {
                    Tableau[i] = true;

                }
                if (rng.Next(0, 2) == 2)
                {
                    Tableau[i] = false;
                }


            }
            Tableau[0] = true;
            Tableau[99] = true;

            while (app.ToLower() != "q" || app.ToLower() != "p")
            {
                if (app == "w")
                {
                    Console.WriteLine("pour quitter appuyer sur Q");
                    app = "e";
                }
                Console.WriteLine("Pour vous déplacez appuyer sur: A, S, D, G, H, Y, P ");
                touche = Console.ReadLine();




                if (touche.ToLower() == "p")
                {
                    Affichage10();

                }



                if (touche.ToLower() == "y")
                {

                    AffichageEntier();


                }



                if (touche.ToLower() == "a")
                {
                    position -= 3;
                }
                if (touche.ToLower() == "s")
                {
                    position -= 2;
                }
                if (touche.ToLower() == "d")
                {
                    position -= 1;
                }
                if (touche.ToLower() == "g")
                {
                    position += 2;
                }
                if (touche.ToLower() == "h")
                {
                    position += 4;
                }
                if (touche.ToLower() == "q")
                {
                    app = "q";
                }
                Console.WriteLine("\n");
                Console.WriteLine("Vous vous trouvez dans la case " + position + "\n");

                if (Tableau[position - 1] == false)
                {
                    lost++;
                }
                else
                {
                    lost = 0;
                }

                for (int i = 0; i <= 99; i++)
                {
                    if (Tableau[i] == false)
                    {
                        lost++;
                    }

                }

                    if (lost >= 4)
                {
                    Console.WriteLine("Game Over, press q");
                }
                essai++;

                if (app == "q")
                {
                    Console.WriteLine("Au revoir");
                }
                if (lost == 4)
                {
                    Console.WriteLine("Impossibilité d'avancé veuillez quitter, vous avez fait " + essai + " essaies, faite la touche Q");
                }
            }
            Console.ReadLine();
        }
    }
}
