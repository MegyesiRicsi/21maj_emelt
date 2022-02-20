using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class C{
    public int godor;
    public C(string sor)
    {
        var s = sor.Split('\n');
        godor =int.Parse( s[0]);
    }
}
namespace Gödrök
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<C>();
            var sr = new StreamReader("melyseg.txt");
            while (!sr.EndOfStream)
            {
                lista.Add(new C(sr.ReadLine()));
            }
            sr.Close();
            Console.Write($"1. feladat\nA fajl adatainak szama: {lista.Count()}\n");
            Console.Write("\n2. feladat\nAdjon be egz tavolsagerteket! ");
            int szam = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ezen a helyen a felszin{lista[szam].godor} meter melyen van.\n");
            var ures = (from sor in lista where sor.godor == 0 select sor).Count();
            Console.Write($"3. feladat\nAz erntetlen szakasz teruleti aranya {(double)ures/lista.Count()*100:0.##}%.\n");
            var sw = new StreamWriter("godrok.txt");
            var godorszam = 0;
            for (int i = 6; i < lista.Count()-1; i++)
            {
                if (lista[i].godor > 0 )
                {
                    sw.Write(lista[i].godor+" ");
                    
                }
                else if (lista[i+1].godor>0 && lista[i].godor==0)
                {
                    sw.WriteLine();
                    godorszam++;
                }
               
            }
            sw.Close();
            Console.WriteLine($"\n5. feladat\nA godrok szama: {godorszam+1}\n");
            if (lista[szam].godor==0)
            {
                Console.WriteLine("Az adott helyen nincs gödör.\n");
            }
            else
            {
                Console.WriteLine("a");
                int kezdet = 0;
                    int veg = 0;
                while (true)
                {
                    if (lista[szam-1].godor== 0)
                    {
                        kezdet = szam;
                        Console.Write($"A gödör kezdete: {szam+1} méter");
                        while (true)
                        {
                            if (lista[szam + 1].godor == 0)
                            {
                                Console.Write($", a gödör vége: {szam + 1} méter.\n");
                                veg = szam+1;
                                break;
                            }
                            szam++;
                        }
                        break;
                           
                        
                    }
                    szam--;
                }
                Console.WriteLine("c");
                int max = 0;
                var v = new List<int>();
                for (int i = kezdet; i < veg; i++)
                {
                    if (lista[i].godor>max)
                    {
                        max = lista[i].godor;
                    }
                    v.Add(lista[i].godor);
                }
                Console.WriteLine(max);
                Console.WriteLine("d");               
                var terfogat = (from sor in v select sor * 10).Sum();
                Console.WriteLine(terfogat);
                Console.WriteLine("e");
                var felszin = terfogat - 10 * (veg - kezdet );
                Console.WriteLine(felszin);
            }

            Console.ReadKey();
        }
    }
}
