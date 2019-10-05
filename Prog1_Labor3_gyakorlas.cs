using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak3
{
    class Program
    {
        private static readonly int size = 5; // A tömb mérete

        // Véletlenszámok [min, max[ intervallumon
        private static readonly int min = 0;
        private static readonly int max = 10;

        static void Main(string[] args)
        {
            #region Bevezetes
            // A következő feladatokban az A tömb adott számú egész számot tartalmaz.
            // A tömb elemei 0 és 100 között véletlen számok. A tömb feltöltése érdekében
            // készítsen önálló metódust!
            // • Az A tömb mérete: A.Length segítségével határozható meg
            // • Készítsen metódust, mely kilistázza tömb elemeit!
            // • Minden egyes feladatot külön metódussal valósítson meg!
            // (• Érdemes egy olyan metódust is készíteni, amely egy szám öttel való oszthatóságát vizsgálja.)
            #endregion

            #region orai feladatok elokeszitese
            //int[] A = new int[size];

            //A = TombFeltoltes(A.Length);
            //TombKiiratas(A);
            #endregion

            #region ElemekOsszege
            // 1. Határozza meg a tömb elemeinek összegét! (sorozatszámítás tétel)

            // Console.WriteLine("A tömb elemeinek összege: " + ElemekOsszege(A));

            #endregion

            #region VanEOttelOszthato
            // 2. Szerepel-e a tömbben öttel osztható szám? (eldöntés tétel)
            // bool vanOttelOszthato = VanEOttelOszthato(A);

            // Console.WriteLine((vanOttelOszthato ? "Van" : "Nincs") + " öttel osztható szám a tömbben.");

            #endregion

            #region OttelOszthatoIndexe
            // 3. Ha tudjuk, hogy szerepel a tömbben öttel osztható szám, akkor mi az indexe? (kiválasztás tétel)

            // Console.WriteLine("Az első öttel osztható szám indexe: " + (vanOttelOszthato ? OttelOszthatoIndexe(A).ToString() : "-"));

            #endregion

            #region OttelOszthatoIndexe (es mi az)
            // 4.Szerepel-e a tömbben öttel osztható szám, és ha igen, akkor mi az indexe?
            // (A metódus visszatérési értéke - 1 legyen, ha nincs öttel osztható szám,
            // egyébként pedig a megfelelő elem indexe.) (lineáris keresés tétel)

            //int index = OttelOszthatoIndexe(A);

            //Console.WriteLine((index == -1 ? "Nincs" : "Van") + " öttel osztható szám a tömbben, indexe: " + (index == -1 ? "-" : index.ToString()));

            #endregion


            #region
            // Gyak 1. Olvasson be maximum n db egész számot egy tömbbe, ezután döntse el a negatívok összegét, a pozitívok átlagát és a zérusok darabszámát!

            #region felhasznalo altal megadott input beolvasasa
            /*
            Console.WriteLine("Hány db számot szeretnél beolvasni a tömbbe?");
            int n = BeolvInt();
            int[] tomb = new int[n];

            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine("Add meg a(z) " + (i+1) + ". számot!");
                tomb[i] = BeolvInt();
            }
            */
            #endregion

            #region tesztadatok
            int[] tomb = { 0, 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };
            #endregion

            //TombKiiratas(tomb);

            //Console.WriteLine("A negatív számok összege: " + NegativSzamokOsszege(tomb));

            #endregion

            #region nemnegativ szamok kivalogatasa
            // Gyak 2. Az előző feladat tömbjéből másolja ki egy másik, megfelelő elemszámú tömbbe a nemnegatív számokat.

            //Console.WriteLine("Az eredeti tömb:");
            //TombKiiratas(tomb);

            //tomb = NemnegativKivalogat(tomb);
            //int db = NemnegativKivalogatHelyben(ref tomb);

            //Console.WriteLine("A nemnegatív számok:");
            //TombKiiratas(tomb, db);

            #endregion

            #region honap bekerese
            // Gyak 3. Kérjen be a felhasználótól hónapnevet! Egészen addig ne fogadja el a bemenetet,
            // amíg tényleg hónapnevet nem ír be. (Ellenőrizze: a hónapneveket tömbben tárolja, ha a
            // felhasználó bemenete nem szerepel ebben, akkor kérje újra.)

            //HonapBeker();

            #endregion

            #region gyakorló feladatok stringműveletekkel

            // 1. Írjon programot amely egy stringből eltünteti a szóközöket! Alkalmazza a stringműveleteket!
            //SzokozokTorleseStringbol();

            // 2. Írjon programot, amely egy szövegben megszámolja a magánhangzókat! Alkalmazza a stringműveleteket!
            MghSzamlalas();

            // 3. Készítsen programot, amely egy adott karaktersorozatot(pl. „Amelyik kutya ugat, az a kutya nem harap”)
            // minden adott karaktersorozatát(pl. „kutya”) egy adott karaktersorozatra(pl. „macska”) cseréli!



            #endregion
        }

        private static void MghSzamlalas()
        {
            int mgh = 0;
            string maganhangzok = "aáeéiíoóöőuúüű";

            Console.WriteLine("Írj be egy sornyi szöveget, amelyben szeretnéd megszámlálni a magánhangzókat!");
            string szoveg = Console.ReadLine();

            foreach (char c in szoveg)
            {
                foreach (char m in maganhangzok)
                {
                    if (c.ToString().ToLower().Equals(m.ToString())) {
                        mgh++;
                    }
                }
            }

            Console.WriteLine("A magánhangzók száma az általad megadott szövegben: " + mgh);
        }

        private static void SzokozokTorleseStringbol()
        {
            Console.WriteLine("Írj be egy sornyi szöveget, amiből el szeretnéd tüntetni a szóközöket!");

            //string szoveg = "Jobb egy lúdnyak tíz tyúknyaknál.";
            string szoveg = Console.ReadLine();

            szoveg = szoveg.Replace(" ", string.Empty);

            Console.WriteLine("A szöveg a szóközök eltüntetését követően:");
            Console.WriteLine(szoveg);
        }

        private static void HonapBeker()
        {
            string[] honapok = {
                "január", "február", "március",
                "április", "május", "június",
                "július", "augusztus", "szeptember",
                "október", "november", "december"
            };

            bool van = false;

            Console.WriteLine("Adj meg egy hónapnevet!");
            string honap = Console.ReadLine();
            while (!van)
            {
                for (int i = 0; i < honapok.Length; i++)
                {
                    if (honap.Equals(honapok[i]))
                    {
                        van = true;
                    }
                }

                if (!van)
                {
                    Console.WriteLine("Nem találom a megadott hónapnevet.\n" +
                        "Adj meg egy másikat, vagy próbálkozz újra ugyanezzel. Csak kisbetűket használj!");

                    honap = Console.ReadLine();
                }
            }

            Console.WriteLine("Az általad megadott hónap neve: " + honap);
        }

        private static int NemnegativKivalogatHelyben(ref int[] tomb)
        {
            int db = 0;

            for (int i = 0; i < tomb.Length; i++)
            {
                int elem = tomb[i];

                if (elem >= 0)
                {
                    tomb[db++] = tomb[i];
                }
            }

            return db-1;
        }

        private static int[] NemnegativKivalogat(int[] tomb)
        {
            int n = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] >= 0)
                {
                    n++;
                }
            }

            int[] nemnegativak = new int[n];
            int db = 0;

            for (int i = 0; i < tomb.Length; i++)
            {
                int elem = tomb[i];

                if (elem >= 0)
                {
                    nemnegativak[db++] = elem;
                }
            }

            return nemnegativak;
        }

        private static int NegativSzamokOsszege(int[] tomb)
        {
            int negativakOsszege = 0;

            for (int i = 0; i < tomb.Length; i++)
            {
                int elem = tomb[i];
                if (elem < 0) {
                    negativakOsszege += tomb[i];
                }
                
            }

            return negativakOsszege;
        }

        private static int BeolvInt()
        {
            return int.Parse(Console.ReadLine());
        }

        private static int OttelOszthatoIndexe(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (OttelOszthato(a[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool VanEOttelOszthato(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (OttelOszthato(a[i])) {
                    return true;
                }
            }

            return false;
        }

        private static bool OttelOszthato(int v)
        {
            return v % 5 == 0;
        }

        private static int ElemekOsszege(int[] a)
        {
            int osszeg = 0;

            foreach (int elem in a)
            {
                osszeg += elem;
            }

            return osszeg;
        }

        private static void TombKiiratas(int[] tomb, int db)
        {
            Console.Write("[ ");
            for (int i = 0; i < db; i++)
            {
                Console.Write(tomb[i] + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        private static void TombKiiratas(int[] a)
        {
            Console.Write("[ ");
            foreach (int elem in a)
            {
                Console.Write(elem + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        private static int[] TombFeltoltes(int size)
        {
            int[] veletlenSzamok = new int[size];

            Random r = new Random();

            for (int i = 0; i < veletlenSzamok.Length; i++)
            {
                veletlenSzamok[i] = r.Next(min, max);
            }

            return veletlenSzamok;
        }
    }
}
