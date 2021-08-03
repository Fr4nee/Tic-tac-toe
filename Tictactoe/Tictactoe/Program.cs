using System;

namespace Tictactoe
{
    public class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            ConnectionDB conn = new ConnectionDB();
            conn.Openn();
            Console.Clear();
            game.Menu();
        }
    }
}
