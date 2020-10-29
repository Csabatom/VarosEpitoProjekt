using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarosEpitoProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Varos> varosok = new List<Varos>();
            varosok.Add(new Varos("Budapest", 3));
            varosok.Add(new Varos("Kecskemét", 2));
            varosok.Add(new Varos("Noszvaj", 1));

            foreach(var varos in varosok)
            {
                Console.WriteLine(varos);
            }
        }
    }
}
