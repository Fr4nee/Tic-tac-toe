using System;

namespace Tictactoe
{
    class Program
    {
        public static string[,] table = new string[3, 3];
        public static int p1o = 1;
        public static int p2x = 2;
        public static int currentPlayer = Turn(currentPlayer);

        static void Main(string[] args)
        {
            GameFlow();
            Console.ReadKey();
        }
        static void DrawTableDemo()
        {
            Console.WriteLine($"╔═══╦═══╦═══╗");
            Console.WriteLine($"║ 7 ║ 8 ║ 9 ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ 4 ║ 5 ║ 6 ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ 1 ║ 2 ║ 3 ║");
            Console.WriteLine($"╚═══╩═══╩═══╝");
        }
        static void DrawTable()
        {
            Console.WriteLine($"╔══╦══╦══╗");
            Console.WriteLine($"║ {table[0, 0]} ║ {table[0, 1]} ║ {table[0, 2]} ║");
            Console.WriteLine($"╠══╬══╬══╣");
            Console.WriteLine($"║ {table[1, 0]} ║ {table[1, 1]} ║ {table[0, 0]} ║");
            Console.WriteLine($"╠══╬══╬══╣");
            Console.WriteLine($"║ {table[2, 0]} ║ {table[2, 1]} ║ {table[2, 2]} ║");
            Console.WriteLine($"╚══╩══╩══╝");
        }

        static string[,] SelectCoord(string[,] table)
        {
            string[,] aux = new string[3, 3];
            int input;

            Console.Write("Write the coordinates with your NumPad");
            int.TryParse(Console.ReadLine(), out input);

            switch (input)
            {
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("insert a correct option:");
                    break;
            }

            return aux;
        }

        static int Turn(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            return 1;
        }

        static string[,] InsertSymbol(string[,] table)
        {
            string[,] aux = new string[3, 3];

            return aux;
        }

        static int GetWiner()
        {
            int win = 0;

            for (int f = 0; f < table.GetLength(0); f++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    if (table[f, 0] == "x")
                    {

                    }
                    if (table[f, 1] == "x")
                    {

                    }
                    if (table[f, 2] == "x")
                    {

                    }
                    if (table[0, c] == "x")
                    {

                    }
                    if (table[1, c] == "x")
                    {

                    }
                    if (table[2, c] == "x")
                    {

                    }
                }
            }
            return win;
        }

        static void GameFlow()
        {
            DrawTableDemo();
            do
            {
                DrawTable();
                SelectCoord(table);
                GetWiner();                

            } while (GetWiner() == 1);

        }

        // Bienvenida, muestro metodologia de tablero y reglas
        // Seleccion de coordenada del P1
        // Cargo el dato
        // Imprimo el resultado
        // Verifico ganador
        /*****************************************************/
        // Seleccion de coordenada del P2
        // Cargo el dato 
        // Imprimo el resultado
        // Verifico ganador
        /*******************Gana algun jugador****************/
        // Verifico ganador == true / return 1
        // Imprimo ganador




    }
}
