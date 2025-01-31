using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_kozmondasok
{
    internal class Program
    {
        static void sorszamlalo(ref int sorszamlalo) //így tud csak a main ben lévő változó változni
        {
            sorszamlalo++;
        }

        static void hossz(string sor, ref int hossz, ref string max) //így tud csak a main ben lévő változó változni
        {
            int hossza = sor.Length;
            if (hossza > hossz)
            {
                hossz = hossza;
                max = sor;
            }
        }

        static void egyesit(string sorok1, string sorok2, ref string[] egyesitett)
        {
            string[] elsotomb = File.ReadAllLines(sorok1);
            string[] masodiktomb = File.ReadAllLines(sorok2);

            egyesitett = new string[elsotomb.Length + masodiktomb.Length];

            elsotomb.CopyTo(egyesitett, 0); //tömb tartalmat másol tömbbe, kezdő indexre
            masodiktomb.CopyTo(egyesitett, elsotomb.Length);
        }

        static void abc(string sorok1, string sorok2, ref string[] egyesitett)
        {
            string[] elsotomb = File.ReadAllLines(sorok1);
            string[] masodiktomb = File.ReadAllLines(sorok2);

            egyesitett = new string[elsotomb.Length + masodiktomb.Length];

            elsotomb.CopyTo(egyesitett, 0); //tömb tartalmat másol tömbbe, kezdő indexre
            masodiktomb.CopyTo(egyesitett, elsotomb.Length);

            Array.Sort(egyesitett); //rendezi a tömböt

            foreach (string rend in egyesitett)
                Console.WriteLine(rend);
        }

        static void szokoznelkul(string[] sorok)
        {
            int db = 0;
            for (int i = 0; i < sorok.Length; i++)
            {
                foreach (char kar in sorok[i])
                    if (!char.IsWhiteSpace(kar)) //ha nem szóköz 
                        db++;
            }
            Console.WriteLine($"A nem szóköz karakterek száma: {db}");
        }

        static void kiir(string sorok1, string sorok2, ref string[] egyesitett, StreamWriter ki)
        {
            ki.WriteLine("6. feladat:");
            ki.WriteLine();

            string[] elsotomb = File.ReadAllLines(sorok1);
            string[] masodiktomb = File.ReadAllLines(sorok2);

            egyesitett = new string[elsotomb.Length + masodiktomb.Length];

            elsotomb.CopyTo(egyesitett, 0); //tömb tartalmat másol tömbbe, kezdő indexre
            masodiktomb.CopyTo(egyesitett, elsotomb.Length);

            foreach (string sor in egyesitett)
                ki.WriteLine(sor);

            ki.WriteLine();
            Array.Sort(egyesitett); //rendezi a tömböt

            foreach (string rend in egyesitett)
                ki.WriteLine(rend);

            ki.Close();
        }

        static void Main(string[] args)
        {
            /*
             BP - kozmondasok
             BP - 01.28.
            */
            string fejlec = "BP-kozmondasok";
            Console.WriteLine(fejlec);
            for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
            Console.WriteLine();

            string sor1;
            string sor2;
            StreamReader be1 = new StreamReader("szoveg1.txt");
            StreamReader be2 = new StreamReader("szoveg2.txt");

            //6.feladat
            StreamWriter ki = new StreamWriter("kozmondasok.txt");

            int szamol1 = 0;
            int szamol2 = 0;
            sor1 = be1.ReadLine();
            sor2 = be2.ReadLine();
            int hossz1 = 0;
            string max1 = "";
            int hossz2 = 0;
            string max2 = "";

            while (sor1 != null)
            {
                sorszamlalo(ref szamol1);
                hossz(sor1, ref hossz1, ref max1);
                sor1 = be1.ReadLine();
            }

            while (sor2 != null)
            {
                sorszamlalo(ref szamol2);
                hossz(sor2, ref hossz2, ref max2);
                sor2 = be2.ReadLine();
            }

            //1. feladat

            Console.WriteLine("1. feladat:");
            Console.WriteLine($"Az első szöveg állomány (szoveg1) {szamol1} sort tartalmaz");
            Console.WriteLine($"A második szöveg állomány (szoveg2) {szamol2} sort tartalmaz.");

            Console.WriteLine();

            //2. feladat

            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Az első állomány leghosszabb sora: {max1}");
            Console.WriteLine($"A második állomány leghosszabb sora: {max2}");

            //3. feladat

            Console.WriteLine();
            //Console.WriteLine("3. feladat:");

            string[] egyes = null;
            string sorok1 = "szoveg1.txt";
            string sorok2 = "szoveg2.txt";

            egyesit(sorok1, sorok2, ref egyes);

            //4. feladat

            Console.WriteLine("4. feladat:");

            abc(sorok1, sorok2, ref egyes);

            //5. feladat

            Console.WriteLine();
            Console.WriteLine("5. feladat:");

            szokoznelkul(egyes);

            //6. feladat
            kiir(sorok1, sorok2, ref egyes, ki);

            Console.WriteLine();
            Console.WriteLine("Kilépéshez nyonja meg az ENTER billentyűt.");
            Console.ReadLine();
        }
    }
}