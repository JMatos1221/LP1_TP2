using System;

namespace Felli
{
    class Program
    {
        static void Main(string[] args)
        {

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

            GameBoard.Print();
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