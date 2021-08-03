using System;

namespace Tictactoe
{
    class Program
    {
        public static string[,] table = new string[3, 3];
        public static int currentPlayer = 0;

        static void Main(string[] args)
        {
            conectionDB conn = new conectionDB();

            conn.Open();
            GameFlow();
            Console.ReadKey();
        }
        static void DrawTableDemo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**** Welcome to Tic-Tac-Toe ****\n");
            Console.WriteLine($"╔═══╦═══╦═══╗");
            Console.WriteLine($"║ 7 ║ 8 ║ 9 ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ 4 ║ 5 ║ 6 ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ 1 ║ 2 ║ 3 ║");
            Console.WriteLine($"╚═══╩═══╩═══╝");
            Console.WriteLine("Play with your NumPad");
            Console.WriteLine("\nPress Enter to start the game...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        static void DrawTable()
        {
            Console.WriteLine($"╔═══╦═══╦═══╗");
            Console.WriteLine($"║ {table[0, 0], -1} ║ {table[0, 1],-1} ║ {table[0, 2],-1} ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ {table[1, 0],-1} ║ {table[1, 1],-1} ║ {table[1, 2],-1} ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ {table[2, 0],-1} ║ {table[2, 1],-1} ║ {table[2, 2],-1} ║");
            Console.WriteLine($"╚═══╩═══╩═══╝");
        }

        static void SelectCoord(int movement)
        {
            int input;

            bool isEmpty = false;

            do
            {
                Console.Write("Write the coordinates with your NumPad: ");
                input = ValidateNumber();
                switch (input)
                {
                    case 7:
                        isEmpty = Movement(0, 0, movement);
                        break;
                    case 8:
                        isEmpty = Movement(0, 1, movement);
                        break;
                    case 9:
                        isEmpty = Movement(0, 2, movement);
                        break;
                    case 4:
                        isEmpty = Movement(1, 0, movement);
                        break;
                    case 5:
                        isEmpty = Movement(1, 1, movement);
                        break;
                    case 6:
                        isEmpty = Movement(1, 2, movement);
                        break;
                    case 1:
                        isEmpty = Movement(2, 0, movement);
                        break;
                    case 2:
                        isEmpty = Movement(2, 1, movement);
                        break;
                    case 3:
                        isEmpty = Movement(2, 2, movement);
                        break;

                    default:
                        Console.WriteLine("insert a correct option: ");
                        break;
                }

            } while (isEmpty == false);
        }

        private static int ValidateNumber()
        {
            int input;

            while (int.TryParse(Console.ReadLine(), out input) != true)
            {
                Console.WriteLine("Wrong, rewrite your option: ");
                DrawTableDemo();
            }
            return input;
        }

        private static bool Movement(int f, int c, int movement)
        {
            bool isEmpty = false;

            isEmpty = IsEmpty(f, c);

            if (isEmpty == true)
            {
                table[f, c] = ChoosePlayer(movement);
            }
            else
            {
                Console.WriteLine("Error, the cell is already used");
            }
            return isEmpty;
        }

        private static bool IsEmpty(int f, int c)
        {
            bool isEmpty;

            if (table[f, c] == null)
            {
                isEmpty = true;
            }
            else
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        private static string ChoosePlayer(int movementNumber)
        {
            string player = null;
            if (movementNumber % 2 == 0)
            {
                player = "X";
            }
            else
            {
                player = "O";
            }
            return player;
        }

        static bool GetWiner()
        {
            bool win = false;
            if (table[0, 0] == table[0, 1] && table[0, 0] == table[0, 2] && table[0,0] != null)
            {
                win = true;
            }
            else if (table[1, 0] == table[1, 1] && table[1, 0] == table[1, 2] && table[1, 0] != null)
            {
                win = true;
            }
            else if (table[2, 0] == table[2, 1] && table[2, 0] == table[2, 2] && table[2, 0] != null) 
            {
                win = true;
            }
            else if (table[0, 0] == table[1, 1] && table[0, 0] == table[2, 2] && table[0, 0] != null)
            {
                win = true;
            }
            else if (table[0, 2] == table[1, 1] && table[0,2]== table[2, 0] && table[0, 2] != null)
            {
                   win = true;
            }
            else if(table[0,0]== table[1,0] && table[0,0] == table[2, 0] && table[0, 0] != null)
            {
                win = true;
            }
            else if (table[0, 1] == table[1, 1] && table[0, 1] == table[2, 1] && table[0, 1] != null)
            {
                win = true;
            }
            else if (table[0, 2] == table[1, 2] && table[0, 2] == table[2, 2] && table[0, 2] != null)
            {
                win = true;
            }
           return win;
        }

        static void GameFlow()
        {
            int movement = 0;
            bool winner = false;
            DrawTableDemo();
            do
            {
                movement++;
                DrawTable();
                SelectCoord(movement);
                winner = GetWiner();
                Console.Clear();
                if (winner == true)
                {
                    string player = ChoosePlayer(movement);
                    DrawTable();
                    Console.WriteLine($"The winner is: {player}!!!!!");
                }
                if (movement == 9)
                {
                    DrawTable();
                    Console.WriteLine("Game over, is a Tie!");
                    winner = true;
                }
            } while (winner == false);
        }
    }
}
