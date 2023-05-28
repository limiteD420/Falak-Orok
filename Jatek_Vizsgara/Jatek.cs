using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_vizsga2
{
    class Karakter
    {
        static Random rnd = new Random();
        private int pal;

        public Karakter(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }

        public int Pal
        {
            get
            {
                if (pal == 0)
                {
                    pal = X + Y;
                }

                return pal;
            }
        }
        public int Y { get; set; }
        public void Mozog(int irany, char[,] palya)
        {
            switch (irany)
            {
                case 1:
                    X += 1;
                    break;
                case 2:
                    X -= 1;
                    break;
                case 3:
                    Y += 1;
                    break;
                case 4:
                    Y -= 1;
                    break;
                default:
                    break;
            }
        }
        public void Mozog(char[,] palya)
        {
            int xTemp = X;
            int yTemp = Y;
            do
            {
                X = xTemp;
                Y = yTemp;
                Mozog(rnd.Next(1, 5), palya);
            } while (FalnakMegy(palya));
        }
        public bool FalnakMegy(char[,] palya)
        {
            return X < 0 ||
                    Y < 0 ||
                    X > palya.GetLength(0) - 1 ||
                    Y > palya.GetLength(1) - 1 ||
                    palya[X, Y] == 'X';
        }
    }
    class Jatek
    {
        char[,] palya;
        Karakter jatekos;
        List<Karakter> orok = new List<Karakter>();
        public char[,] Palya { get => palya; set => palya = value; }
        internal Karakter Jatekos { get => jatekos; set => jatekos = value; }
        internal List<Karakter> Orok { get => orok; set => orok = value; }
        public Jatek(string[] palya)
        {
            this.palya = new char[palya.Length - 2, palya[0].Length - 2];
            for (int i = 1; i < palya.Length - 1; i++)
            {
                for (int j = 1; j < palya[i].Length - 1; j++)
                {
                    if (palya[i][j] == ' ' || palya[i][j] == 'X')
                    {
                        this.palya[i - 1, j - 1] = palya[i][j];
                    }
                    else
                    {
                        this.palya[i - 1, j - 1] = ' ';
                    }
                    if (palya[i][j] == '*')
                    {
                        Orok.Add(new Karakter(i - 1, j - 1));
                    }
                }
            }
            Jatekos = new Karakter(0, 0);
            this.palya[this.palya.GetLength(0) - 1, this.palya.GetLength(1) - 1] = 'K';
        }
        public void Mozog(int irany)
        {
            Karakter tempJatekos = new Karakter(jatekos.X, jatekos.Y);
            tempJatekos.Mozog(irany, palya);
            if (!tempJatekos.FalnakMegy(palya))
            {
                jatekos.Mozog(irany, palya);
            }
            for (int i = 0; i < orok.Count; i++)
            {
                orok[i].Mozog(palya);
            }
        }
        public bool Vesztettel()
        {
            bool result = false;
            int i = 0;
            do
            {

                if (orok[i].X == jatekos.X && orok[i].Y == jatekos.Y)
                {
                    result = true;
                }
                i++;
            } while (i < orok.Count);
            return result;
        }
        public bool Nyertel()
        {
            if (jatekos.X == this.palya.GetLength(0) - 1 && jatekos.Y == this.palya.GetLength(1) - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}