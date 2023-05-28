using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_vizsga2
{
    class Nezet
    {
        Jatek jatek;
        public Nezet(Jatek jatek)
        {
            Console.CursorVisible = false;

            this.jatek = jatek;
        }

        public void Kiir(int x, int y)
        {
            Console.Clear();
            Keret(x, y, jatek.Palya.GetLength(0), jatek.Palya.GetLength(1));
            PalyaRajz(x + 1, y + 1);
            KarakterekKiir(x + 1, y + 1);
        }

        void KarakterekKiir(int x, int y)
        {
            Console.SetCursorPosition(y + jatek.Jatekos.Y, x + jatek.Jatekos.X);
            Console.Write('O');

            for (int i = 0; i < jatek.Orok.Count; i++)
            {
                Console.SetCursorPosition(y + jatek.Orok[i].Y, x + jatek.Orok[i].X);
                Console.Write('*');
            }
        }

        void PalyaRajz(int x, int y)
        {
            Console.SetCursorPosition(y, x);

            for (int i = 0; i < jatek.Palya.GetLength(0); i++)
            {
                for (int j = 0; j < jatek.Palya.GetLength(1); j++)
                {
                    Console.SetCursorPosition(y + j, x + i);

                    if (jatek.Palya[i, j] == 'K')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(' ');
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write(jatek.Palya[i, j]);
                    }



                }
            }
        }

        void Keret(int x, int y, int n, int m)
        {
            Console.SetCursorPosition(y, x);

            for (int i = 0; i < n + 2; i++)
            {
                if (i == 0 || i == n + 1)
                {
                    for (int j = 0; j < m + 2; j++)
                    {
                        Console.SetCursorPosition(y + j, x + i);
                        Console.Write('X');
                    }
                }
                else
                {
                    Console.SetCursorPosition(y, x + i);
                    Console.Write('X');

                    Console.SetCursorPosition(y + m + 1, x + i);
                    Console.Write('X');
                }
            }
        }
    }
}