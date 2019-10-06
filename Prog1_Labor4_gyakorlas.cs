using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak4
{
    /*
        Egy repülőgéppel egyenes vonalban végigrepültünk egy
        tengerszakasz fölött. Egyenlő távolságonként megmértük,
        hogy a repülő alatt tenger vagy sziget található-e.
        (Legalább 10 mérést végeztünk.) Mérési eredményeinket
        egy tömbben tároltuk el:

            (1) tenger esetén nulla szerepel a tömbben,
            (2) sziget esetén a sziget adott helyen mért magassága.

        Írjon programot, amely véletlenszerűen előállítja a mérési
        eredményeket, majd különböző statisztikai feladatokat old
        meg. Minden részfeladatot különböző metódusokkal
        valósítson meg!
    */

    class Program
    {
        static Random r = new Random();
        static int n = r.Next(5, 21);
        static int[] meresiAdatok = new int[n];
        //static int[] meresiAdatok = { 0, 1, 1, 2, 0, 1, 1 };
        static void Main(string[] args)
        {
            // 1. Valósítsa meg a tömb véletlenszerű feltöltését!40 % a valószínűsége, hogy egy mérési helyen szigetet találunk.
            // A sziget aktuális magassága 1 és 10 közötti véletlen szám.
            
            TombFeltoltes();

            // 2. Jelenítse meg a mérési eredményeket a képernyőn!
            MeresiAdatokKiiratasa();

            // 3. Határozza meg, hogy hol található(először) a legmagasabb pont, és mennyi ennek a magassága!
            // LegmagasabbPontHelyeEsErteke();

            // 4. Adja meg, hogy a legmagasabb pont hányszor fordult elő a repülés során!
            //LegmagasabbPontElofordulasainakSzama();

            // 5. Határozza meg a leghosszabb szigetszakasz hosszát!
            LeghosszabbSzigetszakasz();

            // 6. Adja meg, hogy a leghosszabb szigeten található - e az első maximális magasságú mérési pont!
            LeghosszabbSzigetszakaszLegmagassabbE();
        }

        private static void LeghosszabbSzigetszakaszLegmagassabbE()
        {
            int hossz = 1;
            int leghosszabb = 1;
            bool sziget = false;
            int kezdet = 0;
            int veg = 0;
            int leghosszabbKezdet = 0;
            int leghosszabbVeg = 0;

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                int elem = meresiAdatok[i];

                if (elem != 0)
                {
                    if (!sziget)
                    {
                        kezdet = i;
                        sziget = true;
                        hossz = 1;
                    }
                    else
                    {
                        hossz++;
                    }
                }
                else
                {
                    if (sziget)
                    {
                        sziget = false;
                        veg = i - 1;
                        if (hossz > leghosszabb)
                        {
                            leghosszabb = hossz;
                            leghosszabbKezdet = kezdet;
                            leghosszabbVeg = veg;
                        }
                    }
                }
            }

            int max = 0;
            int index = 0;

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                int elem = meresiAdatok[i];

                if (elem > max)
                {
                    max = elem;
                    index = i;
                }
            }

            if (index >= leghosszabbKezdet && index <= leghosszabbVeg)
            {
                Console.WriteLine("A legmagasabb pont első előfordulási helye a leghosszabb szakaszon található.");
            }
            else {
                Console.WriteLine("A legmagasabb pont első előfordulási helye nem a leghosszabb szakaszon található.");
            }
        }

        private static void LeghosszabbSzigetszakasz()
        {
            int hossz = 1;
            int leghosszabb = 1;
            bool sziget = false;

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                int elem = meresiAdatok[i];

                if (elem != 0)
                {
                    if (!sziget)
                    {
                        sziget = true;
                        hossz = 1;
                    }
                    else
                    {
                        hossz++;
                    }                    
                }
                else {
                    if (sziget)
                    {
                        sziget = false;
                        if (hossz > leghosszabb)
                        {
                            leghosszabb = hossz;
                        }
                    }
                }
            }

            Console.WriteLine("A leghosszabb szigetszakasz " + leghosszabb + " egység");
        }

        private static void LegmagasabbPontElofordulasainakSzama()
        {
            int max = 0;
            int db = 0;

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                int elem = meresiAdatok[i];

                if (elem > max)
                {
                    max = elem;
                }
            }

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                if (meresiAdatok[i] == max)
                {
                    db++;
                }
            }

            Console.WriteLine("A legmagasabb pont " + db + " alkalommal fordult elő.");
        }

        private static void LegmagasabbPontHelyeEsErteke()
        {
            int max = 0;
            int index = 0;

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                int elem = meresiAdatok[i];

                if (elem > max) {
                    max = elem;
                    index = i;
                }
            }

            Console.WriteLine("A legmagasabb pont első előfordulási helye: " + index + ", értéke: " + max);
        }

        private static void MeresiAdatokKiiratasa()
        {
            Console.Write("[ ");

            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                Console.Write(meresiAdatok[i] + " ");
            }

            Console.WriteLine("]");
        }

        private static void TombFeltoltes()
        {
            Random vlsz = new Random();
            for (int i = 0; i < meresiAdatok.Length; i++)
            {
                bool sziget = (vlsz.Next(0, 6) < 3);

                if (sziget)
                {
                    meresiAdatok[i] = 0;
                }
                else {
                    meresiAdatok[i] = r.Next(1, 11);             
                }
            }
        }
    }
}
