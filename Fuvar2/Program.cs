using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fuvar2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> sorok = File.ReadAllLines("fuvar.csv", Encoding.UTF8).ToList();
            List<Fuvarok> fuvarok = new List<Fuvarok>();

            foreach (string item in sorok.Skip(1))
            {
                fuvarok.Add(new Fuvarok(item));
            }

            Console.WriteLine($"3.feladat: {fuvarok.Count()} fuvar");

            var fuvarokSzamaLamdba = (fuvarok.Where(n => n.Azonosito == 6185)).Count();
            var bevetelLambda = fuvarok.Where(n => n.Azonosito == 6185).Select(p => p.Viteldij).Sum();

            Console.WriteLine("Lambdaval:");

            Console.WriteLine($"4. feladat: {fuvarokSzamaLamdba} fuvar alatt {bevetelLambda} $");

            int fuvarokSzama = 0;
            double bevetel = 0;
            foreach (Fuvarok item in fuvarok
                )
            {
                if(item.Azonosito==6185)
                {
                    fuvarokSzama++;
                    bevetel += item.Viteldij;
                }
            }
            Console.WriteLine("Simán");

            Console.WriteLine($"4. feladat: {fuvarokSzama} fuvar alatt {bevetel} $");

            var fizetesiModok = fuvarok.GroupBy(n => n.FizetesModja);

            Console.WriteLine("5. feladat:");
            foreach (var item in fizetesiModok)
            {
                Console.WriteLine($"\t{item.Key}: {item.Count()} fuvar");
                
            }


            double osszesTav = 0;
            foreach (Fuvarok item in fuvarok)
            {
                osszesTav += item.MegtettTavolsag;
            }

            Console.WriteLine("6. feladat: {0:0.00}km", osszesTav*1.6);

            Console.WriteLine("Lambdaval:");
            var osszesKM = fuvarok.Select(x => x.MegtettTavolsag).Sum();

            Console.WriteLine("6. feladat: {0:0.00}km", osszesKM * 1.6);

         

            Console.WriteLine("7.feladat: Leghosszabb fuvar:");

            int leghosszabUtIdo = fuvarok.Select(x => x.Idotartam).Max();

            

            var leghosszabbFuvarAdatai = from x in fuvarok
                                         where x.Idotartam == leghosszabUtIdo
                                         select new { MegtettTavolsag = x.MegtettTavolsag, Viteldij = x.Viteldij, Azonosito = x.Azonosito, Idotartam = x.Idotartam };

           
            foreach (var item in leghosszabbFuvarAdatai)
            {
                
                Console.WriteLine($"\tFuvar hossza: {item.Idotartam} másodperc");
                Console.WriteLine($"\tTaxi azonosito: {item.Azonosito}");
                Console.WriteLine($"\tMegtett távolság:{item.MegtettTavolsag*1,6} km");
                Console.WriteLine($"\tViteldíj: {item.Viteldij}$");
            }

            StreamWriter hibak = new StreamWriter("hibak.txt", true, Encoding.UTF8);
            hibak.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            foreach (Fuvarok item in fuvarok)
            {
                if(item.Idotartam>0 && item.Viteldij>0 && item.MegtettTavolsag==0)
                {
                    hibak.WriteLine($"{item.Azonosito};{item.Indulas};{item.Idotartam.ToString()};{item.MegtettTavolsag.ToString()};{item.Viteldij.ToString()};{item.Borravalo.ToString()};{item.FizetesModja}");
                }
            }
            hibak.Close();


            Console.WriteLine("8.feladat: hibak.txt");
            

            Console.ReadKey();

        }
    }
}
