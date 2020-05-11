using System;

namespace Felli
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            ushort row, col, rowm, colm;
            string command;
            Player playerA, playerB, currentPlayer;

            Board GameBoard = new Board();

            PrintInstructions();

            do
            {

                Console.Write("What color is Player A? [Black] [White]: ");
                command = Console.ReadLine();
                command = Simplify(command);

                if (command == "black")
                {
                    playerA = Player.Black;
                    playerB = Player.White;
                    break;
                }

                else if (command == "white")
                {
                    playerA = Player.White;
                    playerB = Player.Black;
                    break;
                }

                else Console.WriteLine("Invalid option!");

            } while (true);

            do
            {

                Console.Write("What Player goes first? [A] [B] ");
                command = Console.ReadLine();
                command = Simplify(command);

                if (command == "a")
                {
                    currentPlayer = playerA;
                    break;
                }

                else if (command == "b")
                {
                    currentPlayer = playerB;
                    break;
                }

                else Console.WriteLine("Invalid option!");

            } while (true);

            while (run)
            {
                Console.WriteLine($"Turn: {currentPlayer}\n");

                GameBoard.Print();

                Console.Write("Where do you wanna move? ");
                command = Console.ReadLine();

                if (command.Length == 5)
                {
                    row = Convert.ToUInt16(command[0]);
                    col = Convert.ToUInt16(command[1]);
                    rowm = Convert.ToUInt16(command[3]);
                    colm = Convert.ToUInt16(command[4]);
                    row -= 65;
                    col -= 49;
                    rowm -= 65;
                    colm -= 49;

                    if (row >= 0 & row <= 4 & rowm >= 0 & rowm <= 4 &
                        col >= 0 & col <= 2 & colm >= 0 & colm <= 2)
                    {
                        if (!(row == 2 & (col == 0 | col == 2) & rowm == 2 & (colm == 0 | colm == 2)))
                        {
                            if ((MathF.Abs(row - rowm) == 1 & MathF.Abs(col - colm) == 1) |
                                (MathF.Abs(row - rowm) == 1 & col - colm == 0) |
                                row - rowm == 0 & MathF.Abs(col - colm) == 1)
                            {
                                if (GameBoard.CoordinateColor(row, col) == currentPlayer)
                                {
                                    if (GameBoard.CoordinateColor(rowm, colm) == Player.None)
                                    {
                                        GameBoard.MovePiece(currentPlayer, row, col, rowm, colm);
                                        if (currentPlayer == playerA) currentPlayer = playerB;
                                        else currentPlayer = playerA;
                                    }
                                    else Console.WriteLine("Invalid Input");
                                }
                                else Console.WriteLine("Invalid Input");
                            }

                            else if ((MathF.Abs(row - rowm) == 2 & MathF.Abs(col - colm) == 2) |
                                    (MathF.Abs(row - rowm) == 2 & col - colm == 0) |
                                    row - rowm == 0 & MathF.Abs(col - colm) == 2)
                            {
                                if (GameBoard.CoordinateColor(row, col) == currentPlayer &
                                    GameBoard.CoordinateColor(row + (rowm - row) / 2, col + (colm - col) / 2) !=
                                    (currentPlayer & Player.None))
                                {
                                    GameBoard.MoveEatPiece(currentPlayer, row, col, rowm, colm);
                                    if (currentPlayer == playerA) currentPlayer = playerB;
                                    else currentPlayer = playerA;
                                }
                            }

                            else Console.WriteLine("Invalid Input");
                        }

                        else Console.WriteLine("Invalid Input");
                    }
                    else Console.WriteLine("Invalid Input");
                }
                else Console.WriteLine("Invalid Input.");

                run = GameBoard.Check(GameBoard);
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Welcome to Felli!");
            Console.WriteLine("How to play:");
            Console.WriteLine("First the players decide what color(number)" +
            " they wanna play as by typing: black/white or 1/2");
            Console.WriteLine("Then, the players decide who starts the game" +
            " by typing: A or B");
            Console.WriteLine("");
            Console.WriteLine("The Rules are simple:");
            Console.WriteLine("Each player has six pieces on their" +
            " respective triangle");
            Console.WriteLine("Each turn, a piece is moved to a empty space" +
             " in any direction");
            Console.WriteLine(@"You can ""eat"" enemy pieces by hopping over" +
            "them to an empty space");
            Console.WriteLine("You can either move or eat once per turn");
            Console.WriteLine("Players alternate turns until one of the" +
            " players has no more pieces on the board");
            Console.WriteLine("The player with no pieces on the board loses" +
            "the game\n");
        }

        private static string Simplify(string s)
        {
            return s.Trim().ToLower();
        }
    }
}