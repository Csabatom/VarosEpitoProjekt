using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VarosEpitoProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // ALAPJÁTÉK INICIALIZÁLÁSA
            int kor = 0;

            List<Varos> varosok = new List<Varos>();
            varosok.Add(new Varos("Budapest", 3));
            varosok.Add(new Varos("Kecskemét", 2));
            varosok.Add(new Varos("Noszvaj", 1));

            printGepVarosok();

            string varosnev;
            int meret = -1;
            Console.Write("\nAdja meg a városának a nevét: ");
            varosnev = Console.ReadLine();
            while(meret > 3 || meret < 1)
            {
                Console.Write("Adja meg a városának a méretét (1-3): ");
                meret = int.Parse(Console.ReadLine());
            }
            Varos felhasznaloVarosa = new Varos(varosnev, meret);
            Console.WriteLine();
            menuMegjelenitese();

            void menuMegjelenitese()
            {
                kor++;
                char valasztottMenupont = ' ';
                Console.WriteLine("a.) Lakosokat betelpíteni");
                Console.WriteLine("b.) Házat építeni");
                Console.WriteLine("c.) Üzletet építeni");
                Console.WriteLine("d.) Kilépni");
                while (valasztottMenupont != 'a' && valasztottMenupont != 'b' && valasztottMenupont != 'c' && valasztottMenupont != 'd')
                {
                    Console.WriteLine();
                    Console.WriteLine("Választás: ");
                    try
                    {
                        valasztottMenupont = char.Parse(Console.ReadLine());
                    } catch
                    {
                        Console.Clear();

                        valasztottMenupont = ' ';
                    }
                }
                switch (valasztottMenupont)
                {
                    case 'a':
                        Console.WriteLine("Mennyi lenne a lakosok száma? Jelenlegi lakosszám: " + felhasznaloVarosa.Lakosok);
                        // FELHASZNÁLÓ VÁROSÁBAN A LAKOSOK SZÁMÁNAK BEÁLLÍTÁSA
                        felhasznaloVarosa.Lakosok = int.Parse(Console.ReadLine());
                        Console.Clear();
                        gepJatekos();
                        printGepVarosok();
                        Console.WriteLine();
                        menuMegjelenitese();
                        break;
                    case 'b':
                        Random rnd = new Random();
                        int pluszHazakSzama = rnd.Next(10, 20);
                        felhasznaloVarosa.Hazak += pluszHazakSzama;
                        Console.WriteLine("A házak száma növelve ennyivel: " + pluszHazakSzama + ". Jelenlegi házak száma: " + felhasznaloVarosa.Hazak);
                        Console.ReadKey();
                        Console.Clear();
                        gepJatekos();
                        printGepVarosok();
                        Console.WriteLine();
                        menuMegjelenitese();
                        break;
                    case 'c':
                        int felhasznaloVarosaUzletek = felhasznaloVarosa.Uzletek;
                        if (felhasznaloVarosa.uzletetEpit(10) == false)
                        {
                            Console.WriteLine("Elvesztette a játékot!");
                            Console.ReadKey();
                        } else {
                            felhasznaloVarosa.uzletetEpit(10);
                            Console.WriteLine("Üzletek száma: " + felhasznaloVarosa.Uzletek);
                            Console.ReadKey();
                            Console.Clear();
                            gepJatekos();
                            printGepVarosok();
                            Console.WriteLine();
                            menuMegjelenitese();
                        }
                        break;
                    case 'd':
                        Environment.Exit(0);
                        break;
                }
            }

            void printGepVarosok()
            {
                foreach (var varos in varosok)
                {
                    Console.WriteLine(varos);
                }
            }

            void gepJatekos()
            {
                Console.WriteLine("A gép:");
                foreach(var gepVarosa in varosok)
                {
                    if(kor % 2 == 0)
                    {
                        // PÁROS KÖR
                        gepVarosa.Hazak += 15;
                        gepVarosa.Lakosok += 10;
                    } else
                    {
                        // PÁRATLAN KÖR
                        gepVarosa.uzletetEpit(10);
                        gepVarosa.Lakosok += 20;
                    }
                }
            }
        }
    }
}
