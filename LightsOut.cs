using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CserelgetosJatek
{
    /*
        Egy játéktábla mezői kétféle módon vannak megjelölve(pl. * és -).
        Kezdetben minden mező azonos jelölésű(-), kivéve a játéktábla közepén lévő mező,
        valamint annak négy közvetlen szomszédja.
        A játék során a felhasználó megadja a játéktábla egy koordinátáját.
        A kiválasztott koordinátájú mező, illetve annak négy szomszédja az addigival ellentétes jelölésűre változik.
        A játék akkor ér véget, ha a felhasználó minden mezőt *-ra tudott változtatni.
    */

    /*
        A játéktábla aktuális állapotát egy kétdimenziós logikai tömbben tárolja el!
        Megvalósítandó metódusok:
        1. static bool[,] Init() A játéktábla kezdeti állapotát előállító metódus
        2. static stringState(bool[,] game) A játéktábla aktuális állapotát stringformában megadó metódus
        3. static bool[,] Shoot(bool[,] game, intx, inty) Kiválasztott pontra „lövést” megvalósító metódus
        4. static boolIsOver(bool[,] game) A metódus vizsgálja, hogy minden mező *-gá vált-e
    */
    class Program
    {
        static int size = 5;
        static readonly int[,] neighbors = new int[,] { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } };
        static void Main(string[] args)
        {
            bool[,] game = new bool[size, size];

            game = Init();

            while (!IsOver(game)) {
                int x;
                int y;

                Console.Clear();
                Console.WriteLine(State(game));
                Console.WriteLine("Simple lights out game. When you \"shoot\" somewhere," +
                    "\nthe particular field and its 4 neighbors switch state.\n" +
                    "The goal is to turn all the lights out.\n");
                Console.WriteLine("Where do you want to shoot? (coordinates between 1 and " + size + ")");
                Console.WriteLine("row:");
                y = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("column:");
                x = int.Parse(Console.ReadLine()) - 1;

                Shoot(game, x, y);
            }

            Console.Clear();
            Console.WriteLine(State(game));
            Console.WriteLine("You Win!");
        }

        private static string State(bool[,] game)
        {
            string state = "";

            for (int row = 0; row < game.GetLength(0); row++)
            {
                for (int col = 0; col < game.GetLength(1); col++)
                {
                    state += (game[row, col] == false ? "*" : "-");
                }
                state += "\n";
            }
            return state;
        }

        private static bool[,] Init()
        {
            bool[,] game = new bool[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    game[row, col] = false;
                }
            }

            // A középső mező és 4 szomszédja átállítása
            int rowMiddle = (size - 1) / 2;
            int colMiddle = (size - 1) / 2;

            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                game[rowMiddle + neighbors[i,0], colMiddle + neighbors[i,1]] = true;
            }
            return game;
        }

        private static bool IsOver(bool[,] game) {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (!game[row, col]) {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool[,] Shoot(bool[,] game, int x, int y)
        {
            game[y, x] = !game[y, x];

            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int yCoord = y + neighbors[i, 0];
                int xCoord = x + neighbors[i, 1];

                if (yCoord >= 0 && xCoord >= 0 && yCoord < size && xCoord < size)
                {
                    game[yCoord, xCoord] = !game[yCoord, xCoord];
                }
            }

            return game;
        }
    }
}
