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
            Varos varos = new Varos("Budapest", 2);
            Console.WriteLine(varos);
            Console.ReadKey();
        }
    }
}
