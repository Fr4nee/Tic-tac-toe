using System;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            ConnectionDB conn = new ConnectionDB();
            conn.Openn();

            while (1 < 2)
            {
                Console.Clear();
                game.GameFlow();
                Console.ReadKey();
            }

        }
    }
}
