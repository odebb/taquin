using System;
using System.Collections.Generic;
using System.Text;

namespace Taquin
{
    public class JouerUnePartie
    {
        static public void Main(string[] args)
        {
            Console.WriteLine("dimensions du taquin svp");
            int dimension = Convert.ToInt32(Console.ReadLine());

            Taquin unTaquin = new Taquin(dimension);
            Console.WriteLine(unTaquin);
            while (unTaquin.Gagné() == false)
            {
                ConsoleKey choix =  Console.ReadKey().Key;
                Console.Clear();
                switch (choix)
                {                    
                    case ConsoleKey.DownArrow:
                        unTaquin.Jouer(2);
                        break;
                    case ConsoleKey.LeftArrow:
                        unTaquin.Jouer(4);
                        break;
                    case ConsoleKey.RightArrow:
                        unTaquin.Jouer(6);
                        break;
                    case ConsoleKey.UpArrow:
                        unTaquin.Jouer(8);
                        break;
                    default:
                        Console.WriteLine("utilisez les touches de direction");
                        break;
                }
                Console.WriteLine(unTaquin);
            }
            Console.WriteLine("vous avez gagné");


            Console.Read();
        }
    }
}
