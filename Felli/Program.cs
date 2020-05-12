using System;

namespace Felli
{
    class Program
    {
        /// <summary>
        /// Main function, the program starts here
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            //Main variables declaration
            bool run = true;
            ushort row, col, rowm, colm;
            string command;
            Player playerA = Player.None, playerB = Player.None,
                currentPlayer = Player.None;

            //Creating the Game Board
            Board GameBoard = new Board();

            //Printing Instruction
            PrintInstructions();

            /// <summary>
            /// Do While cycle to set player A and B colors, can quit
            /// </summary>
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

                else if (command == "quit")
                {
                    Console.WriteLine("\nThe game will now quit.");
                    run = false;
                }

                else Console.WriteLine("Invalid option!");

            } while (command != "quit");
            
            /// <summary>
            /// Do while cycle to choose which player starts, can quit
            /// </summary>
            while (command != "quit")
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

                else if (command == "quit")
                {
                    Console.WriteLine("\nThe game will now quit.");
                    run = false;
                    break;
                }

                else Console.WriteLine("Invalid option!");

            }

            /// <summary>
            /// Core Game Loop
            /// </summary> 
            while (run)
            {
                /// <summary>
                /// Prints the player's current turn name
                /// /// </summary>
                Console.WriteLine($"\nTurn: {currentPlayer} [{(int)currentPlayer}]");

                // Prints the GameBoard
                GameBoard.Print();

                // Reads current player's input (move, help or quit)
                Console.Write("Where do you wanna move? ");
                command = Console.ReadLine();

                // Checks if the command's length is 5
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

                    // Checks if the input coordinates are in range A to E, 1 to 5
                    if (row >= 0 & row <= 4 & rowm >= 0 & rowm <= 4 &
                        col >= 0 & col <= 4 & colm >= 0 & colm <= 4)
                    {
                        // Checks if the inserted coordinates have pieces on them
                        if (!(GameBoard.Coordinate(row, col) == null | GameBoard.Coordinate(rowm, colm) == null))
                        {
                            // Checks if the desired move is legal
                            if ((MathF.Abs(row - rowm) == 1 & MathF.Abs(col - colm) == 1) |
                                (MathF.Abs(row - rowm) == 1 & col - colm == 0) |
                                row - rowm == 0 & MathF.Abs(col - colm) == 1)
                            {
                                /// <summary>
                                /// Checks if the selected piece belongs to the player
                                /// </summary>
                                /// <returns>true/false</returns>
                                if (GameBoard.CoordinateColor(row, col) == currentPlayer)
                                {
                                    /// <summary>
                                    /// Checks if the desired position is empty, if yes, moves
                                    /// </summary>
                                    /// <returns>true/false</returns>
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

                            /// <summary>
                            /// 
                            /// </summary>
                            /// <param name="row">Selected Piece row</param>
                            /// <param name="col">Selected Piece column</param>
                            /// <param name="rowm">Desired position row</param>
                            /// <param name="colm">Desired position column</param>
                            /// <returns></returns>
                            else if ((MathF.Abs(row - rowm) == 2 & MathF.Abs(col - colm) == 2) |
                                    (MathF.Abs(row - rowm) == 2 & col - colm == 0) |
                                    row - rowm == 0 & MathF.Abs(col - colm) == 2)
                            {
                                /// <summary>
                                /// Checks if the piece belongs to the current player and if there's an enemy piece in between the move
                                /// </summary>
                                /// <returns>true/false</returns>
                                if (GameBoard.CoordinateColor(row, col) == currentPlayer &
                                    GameBoard.CoordinateColor(row + (rowm - row) / 2, col + (colm - col) / 2) !=
                                    (currentPlayer & Player.None))
                                {
                                    // Moves and eats the enemy piece
                                    GameBoard.MoveEatPiece(currentPlayer, row, col, rowm, colm);
                                    if (currentPlayer == playerA) currentPlayer = playerB;
                                    else currentPlayer = playerA;
                                }
                                else Console.WriteLine("Invalid Input");
                            }
                            else Console.WriteLine("Invalid Input");
                        }
                        else Console.WriteLine("Invalid Input");
                    }
                    else Console.WriteLine("Invalid Input");
                }
                else
                {
                    command = Simplify(command);

                    if (command == "help") PrintInstructions();

                    else if (command == "quit")
                    {
                        Console.WriteLine("\nThe game will now quit.");
                        break;
                    }

                    else Console.WriteLine("Invalid Input.");
                }

                // Checks if the game has ended (Someone ran out of pieces)
                run = GameBoard.Check(GameBoard);
            }

            if (command != "quit")
            {
                GameBoard.Print();

                if (Board.GetWinner() == playerA) Console.Write($"Player A ({playerA}) Wins!");

                else Console.Write($"Player B ({playerB}) Wins!");
            }
        }

        /// <summary>
        /// Prints instructions
        /// </summary>
        private static void PrintInstructions()
        {
            Console.WriteLine("\nWelcome to Felli!");
            Console.WriteLine("How to play:");
            Console.WriteLine("First the players decide what color(number)" +
                " they wanna play as by typing: black/white or 1/2");
            Console.WriteLine("Then, the players decide who starts the game" +
                " by typing: A or B");
            Console.WriteLine("To move your piece simply type the coordinate" +
                " of your piece and the coordinate to where you want" +
                " to move it e.g. C2 D2");
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
                " the game");
            Console.WriteLine("To print this menu again type help");
            Console.WriteLine("To leave the game type quit\n");
        }

        /// <summary>
        /// Removes white spaces and converts all characters to lowercase
        /// </summary>
        /// <param name="s">Desired string to conver</param>
        /// <returns>String</returns>
        private static string Simplify(string s)
        {
            return s.Trim().ToLower();
        }
    }
}