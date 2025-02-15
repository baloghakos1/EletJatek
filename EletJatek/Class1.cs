using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EletJatek.Game;


namespace EletJatek
{
    internal class Game
    {
    }

    internal class Info
    {
        public int Sor { get; set; }
        public int Oszlop { get; set; }
        public Mezo.Jelek Jel { get; set; }
        public Info(int Sor, int Oszlop, Mezo.Jelek Jel = Mezo.Jelek.Ures)
        {
            this.Sor = Sor;
            this.Oszlop = Oszlop;
            this.Jel = Jel;
        }
    }

    internal class Mezo
    {
        public enum Jelek
        {
            Ures = 0,
            Foglalt = 1,
        }
        public Jelek Jel { get; set; }

        public Mezo()
        {
            Jel = Jelek.Ures;
        }
    }

    internal class Jatek
    {
        static Random rnd = new Random();
        private int sorDb, oszlopDb;
        public Mezo[,] tabla;
        public bool vmi;
        public int[] vmi1;

        public int SorDb
        {
            get { return sorDb; }
            set
            {
                sorDb = value;

            }
        }

        public int OszlopDb
        {
            get { return oszlopDb; }
            set
            {
                oszlopDb = value;
                tablaLetrehozasa();
            }
        }

        public bool Vmi
        {
            get { return vmi; }
            set
            {
                vmi = value;
                leptet(tabla);
            }
        }

        public int[] Vmi1
        {
            get { return vmi1; }
            set
            {
                vmi1 = value;
                ColorChange(vmi1[0], vmi1[1]);
            }
        }

        public Jatek(int sorDb, int oszlopDb)
        {
            SorDb = sorDb;
            OszlopDb = oszlopDb;
        }

        private void ColorChange(int x, int y)
        {
            if (tabla[x, y].Jel == Mezo.Jelek.Ures)
            {
                tabla[x, y].Jel = Mezo.Jelek.Foglalt;
            }
            else
            {
                tabla[x, y].Jel = Mezo.Jelek.Ures;
            }
            
        }

        private void tablaLetrehozasa()
        {
            tabla = new Mezo[SorDb+2, OszlopDb+2];
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = new Mezo();
                }
            }
            tablaFeltoltes(tabla);
        }

        private void tablaFeltoltes(Mezo[,] tabla)
        {
            /*
            for (int i = 1; i < tabla.GetLength(0)-1; i++)
            {
                for (int j = 1; j < tabla.GetLength(1)-1; j++)
                {
                    int vmi = rnd.Next(0, 2);
                    if (vmi == 0)
                    {
                        tabla[i, j].Jel = Mezo.Jelek.Ures;
                    }
                    else if (vmi == 1)
                    {
                        tabla[i, j].Jel = Mezo.Jelek.Foglalt;
                    }
                }
            }
            */
        }

        private void leptet(Mezo[,] tabla)
        {
            List<bool> koord1Ossz = new List<bool>();
            for (int i = 1; i < tabla.GetLength(0)-1; i++)
            {
                for (int j = 1; j < tabla.GetLength(1)-1; j++)
                {
                    if (tabla[i, j].Jel == Mezo.Jelek.Ures)
                    {
                        int a = check(i, j, tabla);
                        if (a == 3)
                        {
                            koord1Ossz.Add(true);
                        }
                        else
                        {
                            koord1Ossz.Add(false);
                        }
                        
                    }
                    else
                    {
                        int b = check1(i, j, tabla);
                        if (b == 2 || b == 3)
                        {
                            koord1Ossz.Add(true);
                        }
                        else if (b == 0 || b == 1)
                        {
                            koord1Ossz.Add(false);
                        }
                        else
                        {
                            koord1Ossz.Add(false);
                        }
                    }
                }
            }
            int szam = 0;
            for (int i = 1; i < tabla.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < tabla.GetLength(1) - 1; j++)
                {
                    if (koord1Ossz[szam])
                    {
                        tabla[i, j].Jel = Mezo.Jelek.Foglalt;
                    }
                    else
                    {
                        tabla[i, j].Jel = Mezo.Jelek.Ures;
                    }
                    szam++;
                }
            }
        }
       

        private int check(int x,int y, Mezo[,] tabla)
        {
            int szam = 0;
            for (int i = x-1; i <= x + 1; i++)
            {
                for (int j = y-1; j <= y+1; j++)
                {
                    if (tabla[i,j].Jel == Mezo.Jelek.Foglalt)
                    {
                        szam++;
                    }
                }
            }
            return szam;
        }

        private int check1(int x, int y, Mezo[,] tabla)
        {
            int szam = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (tabla[i, j].Jel == Mezo.Jelek.Foglalt)
                    {
                        szam++;
                    }
                }
            }
            return szam-1;
        }
    }
}
