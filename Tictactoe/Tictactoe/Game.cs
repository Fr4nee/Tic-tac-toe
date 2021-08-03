using System;
using System.Collections.Generic;
using System.Text;

namespace Tictactoe
{
    public class Game
    {
        public static string[,] table = new string[3, 3];
        public static int currentPlayer = 0;
        public static int movement = 0;

        public static ConnectionDB conn = new ConnectionDB();

        public static void DrawTableDemo()
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
        public static void DrawTable()
        {
            Console.WriteLine($"╔═══╦═══╦═══╗");
            Console.WriteLine($"║ {table[0, 0],-1} ║ {table[0, 1],-1} ║ {table[0, 2],-1} ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ {table[1, 0],-1} ║ {table[1, 1],-1} ║ {table[1, 2],-1} ║");
            Console.WriteLine($"╠═══╬═══╬═══╣");
            Console.WriteLine($"║ {table[2, 0],-1} ║ {table[2, 1],-1} ║ {table[2, 2],-1} ║");
            Console.WriteLine($"╚═══╩═══╩═══╝");
        }

        public static void SelectCoord()
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
                        isEmpty = Movement(0, 0);
                        break;
                    case 8:
                        isEmpty = Movement(0, 1);
                        break;
                    case 9:
                        isEmpty = Movement(0, 2);
                        break;
                    case 4:
                        isEmpty = Movement(1, 0);
                        break;
                    case 5:
                        isEmpty = Movement(1, 1);
                        break;
                    case 6:
                        isEmpty = Movement(1, 2);
                        break;
                    case 1:
                        isEmpty = Movement(2, 0);
                        break;
                    case 2:
                        isEmpty = Movement(2, 1);
                        break;
                    case 3:
                        isEmpty = Movement(2, 2);
                        break;

                    default:
                        Console.WriteLine("insert a correct option: ");
                        break;
                }

            } while (isEmpty == false);
        }

        public static int ValidateNumber()
        {
            int input;

            while (int.TryParse(Console.ReadLine(), out input) != true)
            {
                Console.WriteLine("Wrong, rewrite your option: ");
                DrawTableDemo();
            }
            return input;
        }

        public static bool Movement(int f, int c)
        {

            string column = null;
            int row = 0;

            bool isEmpty = false;
            string player = null;

            isEmpty = IsEmpty(f, c);

            if (isEmpty == true)
            {
                player = ChoosePlayer();
                table[f, c] = player;

                if (c == 0)           
                    column = "A";
                else if (c == 1)
                    column = "B";
                else if (c == 2)
                    column = "C";

                if (f == 0)
                    row = 1;
                else if (f == 1)
                    row = 2;
                else if (f == 2)
                    row = 3;

                conn.UpdateMovement(row, column, player);
            }
            else
            {
                Console.WriteLine("Error, the cell is already used");
            }
            return isEmpty;
        }

        public static bool IsEmpty(int f, int c)
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

        public static string ChoosePlayer()
        {
            string player = null;

            if (movement % 2 == 0)
            {
                player = "X";
            }
            else
            {
                player = "O";
            }
            return player;
        }

        public static bool GetWiner()
        {
            bool win = false;
            if (table[0, 0] == table[0, 1] && table[0, 0] == table[0, 2] && table[0, 0] != null)
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
            else if (table[0, 2] == table[1, 1] && table[0, 2] == table[2, 0] && table[0, 2] != null)
            {
                win = true;
            }
            else if (table[0, 0] == table[1, 0] && table[0, 0] == table[2, 0] && table[0, 0] != null)
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

        public void GameFlow()
        {
            bool winner = false;
            DrawTableDemo();
            conn.RestartGame();
            do
            {
                movement++;
                DrawTable();
                SelectCoord();
                winner = GetWiner();
                Console.Clear();
                if (winner == true)
                {
                    string player = ChoosePlayer();
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

            Reset();
        }


        public static void Reset()
        {
            for (int f = 0; f < table.GetLength(0); f++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    table[f, c] = null;
                }
            }
        }





    }
}

