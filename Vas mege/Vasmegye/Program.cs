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
        public string asd;
        public int m, ehn, sss, kk;      
        public bool k;
        public C(string sor)
        {
            asd = sor.Replace("-", "");
            var s = sor.Split('-');
            m = int.Parse(s[0]);
            ehn = int.Parse(s[1]);
            sss = int.Parse(s[2]);
            double fs = 0;
            int szor = 10;
            int kk =sss.ToString()[3];
            for (int i = 0; i < asd.Length-1; i++)
            {
                fs += asd[i] * szor;
                szor--;
            }
            fs = fs % 11;
           
            if (fs==kk)
            {
                k = true;
            }
            else
            {
                k = false;

            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sr =new StreamReader ("vas.txt");
            var lista = new List<C>();
            while (!sr.EndOfStream)
            {
                lista.Add(new C(sr.ReadLine()));
            }
            Console.WriteLine(lista[0].k);
            Console.ReadKey();

        }
    }
}
