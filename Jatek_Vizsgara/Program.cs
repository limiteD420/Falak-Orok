using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_vizsga2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] palya = File.ReadAllLines("palya.txt");
            int lepes = 0;
            Jatek jatek = new Jatek(palya);
            Nezet nezet = new Nezet(jatek);
            do
            {
                nezet.Kiir(0, 0);
                ConsoleKeyInfo gomb = Console.ReadKey();
                switch (gomb.Key)
                {
                    case ConsoleKey.UpArrow:
                        lepes = 2;
                        break;
                    case ConsoleKey.DownArrow:
                        lepes = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        lepes = 4;
                        break;
                    case ConsoleKey.RightArrow:
                        lepes = 3;
                        break;
                    default:
                        break;
                }
                jatek.Mozog(lepes);
            } while (!jatek.Vesztettel() && !jatek.Nyertel());

            if (jatek.Vesztettel())
            {
                Console.Clear();
                Console.WriteLine("VESZTETTÉL!");
            }
            else if (jatek.Nyertel())
            {
                Console.Clear();
                Console.WriteLine("NYERTÉL!");
            }

            Console.ReadLine();
        }
    }
}