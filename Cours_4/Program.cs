using System;
using System.Text.RegularExpressions;

namespace Cours_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Connect4();
            Regex rx = new Regex(@"^[+]?[1-7]+$");
            do
            {
                Display(game);
                for (;;)
                {
                    Console.WriteLine($"Player {game.PlayerNumber()} : Which column 1-{game.ColCount-6} ?");

                    var turn = Console.ReadLine();
                    int column;
                    if (!rx.IsMatch(turn))
                    {
                        Console.Error.WriteLine("Invalid input.");
                    }
                    else if (Int32.Parse(turn) < 1 || Int32.Parse(turn) > game.ColCount)
                    {
                        Console.Error.WriteLine("Invalid column number.");
                    }
                    else if (int.TryParse(turn, out column))
                    {
                        game.Play(column);
                        break;
                    }
                }
            } while (!game.Ended());

            Display(game);
            if (game.Winner() == 3)
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine($"Player {game.Winner()} wins.");
            }
        }

     

        private static void Display(Connect4 game)
        {
            for (int y = 3; y < game.LineCount - 3; y++)
            {
                for (int x = 3; x < game.ColCount - 3; x++)
                {
                    Console.Write($"| {game.GetPawn(x, y)} ");
                }

                Console.WriteLine("|");
                for (int x = 3; x < game.ColCount - 3; x++)
                {
                    Console.Write($"+---");
                }

                Console.WriteLine("+");
            }

            for (int x = 3; x < game.ColCount - 3; x++)
            {
                Console.Write($"  {x - 2} ");
            }

            Console.WriteLine();
        }
    }
}