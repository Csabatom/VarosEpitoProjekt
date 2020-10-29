using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarosEpitoProjekt
{
    class Varos
    {
        private String nev;
        private int lakosok;
        private int hazak;
        private int uzletek;

        public Varos(string nev, int meret)
        {
            this.nev = nev;
            switch(meret)
            {
                case 1:
                    this.hazak = 150;
                    this.uzletek = 20;
                    break;
                case 2:
                    this.hazak = 300;
                    this.uzletek = 45;
                    break;
                case 3:
                    this.hazak = 450;
                    this.uzletek = 50;
                    break;
            }
            this.lakosok = MaxLakosok / 2;
        }

        public string Nev { get => nev; }
        public int Lakosok { get => lakosok; set {
                if (lakosok < value) {
                    if (value > MaxLakosok) {
                        Console.WriteLine("HIBA! A maximális lakosszámot átlépte a beállított lakosszám!");
                    } else {
                        lakosok = value;
                    }
                } else {
                    Console.WriteLine("HIBA! Nem lehet az aktuális lakosok számánál kisebb a beállított lakosok száma!");
                }
            }
        }
        public int Hazak { get => hazak; set { if (MaxLakosok < lakosok) {
                    Console.WriteLine("HIBA! Maxlakosokat átlépte a lakosszám!");
                } else
                {
                    hazak = value;
                }
            }
        }
        public int Uzletek { get => uzletek; }
        public int MaxLakosok { get => hazak*6; }
        public double Alapterulet { get => hazak*110+uzletek*85.5; }

        public bool uzletetEpit(int db)
        {
            if(db <= 0)
            {
                Console.WriteLine("HIBA! Nem lehet a darab negatív szám!");
                return false;
            } else
            {
                if (lakosok / 20 > uzletek)
                {
                    this.uzletek += db;
                    return true;
                }
                else
                {
                    // MAXÜZLETEK BEÁLLÍTÁSA
                    int maxUzletek = lakosok / 20;
                    Console.WriteLine("Több üzletet már nem építhet! Üzletek száma: " + maxUzletek + "/" + uzletek);
                    return false;
                }
            }
        }

        int compareTo(Varos masikVaros)
        {
            if(Alapterulet == masikVaros.Alapterulet)
            {
                // A KÉT ALAPTERÜLET MEGEGYEZIK
                return 0;
            } else if(Alapterulet < masikVaros.Alapterulet)
            {
                // THIS VÁROS ALAPTERÜLETE KISEBB
                return -1;
            } else
            {
                // THIS VÁROS ALAPTERÜLETE NAGYOBB
                return 1;
            }
        }

        public override string ToString()
        {
            return nev + " – Lakosok: " + lakosok + "/" + MaxLakosok + " – Üzletek: " + uzletek + " – Alapterület: " + Alapterulet + " m²";
        }
    }
}
