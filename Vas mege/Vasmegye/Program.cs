using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vasmegye
{
   
    class C
    {
        
        public int m, ehn, sss,year;
        public string fullsor, eredeti,ev;
        public C(string sor)
        {
            fullsor = sor.Replace("-","");
            eredeti = sor;
            var s = sor.Split('-');
            m = int.Parse(s[0]);
            ehn = int.Parse(s[1]);
            sss = int.Parse(s[2]);
            ev =fullsor.Substring(1, 2);
            if (int.Parse(ev)>90)
            {
                year =int.Parse( "19" + ev);
            }
            else
            {
                year= int.Parse("20" + ev);
            }

        }

        
    }
    
    class Program
    {
        static bool CdvEll(string sor)
        {
            
              sor = sor.Replace("-", "");
              
            int fs=0;
             for (int i = 0; i < sor.Length - 1; i++)
             {
                 fs += int.Parse(sor[i].ToString()) * (10-i);
                 
             }           
             fs = fs % 11;          
            return fs==int.Parse(sor[10].ToString());
             
        }
        //1-980227-1258
        static void Main(string[] args)
        {
            var sr = new StreamReader("vas.txt");
            var lista = new List<C>();
            while (!sr.EndOfStream)
            {
                lista.Add(new C(sr.ReadLine()));
            }
            Console.WriteLine("2. feladat: Adatok beolvasása, tárolása");

            // Console.WriteLine($"4. feladat: Ellenőrzés{ lista.Count()});
            Console.WriteLine("4. feladat: Ellenörzés");
            for (int i = 0; i < lista.Count(); i++)
            {
                if (!CdvEll(lista[i].fullsor))
                {
                    Console.WriteLine($"\tHibás a {lista[i].eredeti} személyi azonosító!");
                    lista.Remove( lista[i]);
                }
            }
            var fiu = (from sor in lista where sor.m == 1 || sor.m == 3 select sor).Count();
            Console.WriteLine($"5. feladat: Vas megyében a vizsgált évek alatt {lista.Count()} csecsemő született.");
            Console.WriteLine($"6. feladat: Fiúk száma:{fiu}");
            var minmax = (from sor in lista orderby sor.year select sor.year);
            Console.WriteLine($"7. feladat: Vizsgált időszak: {minmax.First()} - {minmax.Last()}");
            var szoko = (from sor in lista
                         where sor.year % 4 == 0
                         && sor.fullsor.Substring(3, 4).Contains("0224")
                         select sor);           
            if (szoko.Any())
            {
                Console.WriteLine("8. feladat: Szökőnapon született baba!");
            }
            else
            {
                Console.WriteLine("8. feladat: Szökőnapon nem született baba!");
            }
            var stat = (from sor in lista group sor by sor.year);
            Console.WriteLine("9. feladat: Statisztika");
            foreach (var item in stat)
            {
                Console.WriteLine($"\t{item.Key} - {item.Count()} fő");
            }
            Console.ReadKey();

        }
    }
}
