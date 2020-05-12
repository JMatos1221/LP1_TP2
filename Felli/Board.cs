using System;

namespace Felli
{
    public class Board
    {
        /// <summary>
        /// Declared Variables
        /// </summary>
        Piece[,] Coordinates = new Piece[5, 5];
        static Player winner;

        /// <summary>
        /// Board Constructor
        /// </summary>
        public Board()
        {
            for (int i = 0; i < 5; i += 2)
            {
                this.Coordinates[0, i] = new Piece(Player.Black);
            }

            for (int i = 1; i < 4; i += 1)
            {
                this.Coordinates[1, i] = new Piece(Player.Black);
            }

            this.Coordinates[2, 2] = new Piece(Player.None);

            for (int i = 1; i < 4; i += 1)
            {
                this.Coordinates[3, i] = new Piece(Player.White);
            }

            for (int i = 0; i < 5; i += 2)
            {
                this.Coordinates[4, i] = new Piece(Player.White);
            }


        }

        /// <summary>
        /// Method to print the board
        /// </summary>
        public void Print()
        {
            Console.WriteLine("\n      [1][2][3][4][5]");
            Console.WriteLine("     ----------------");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"[{Convert.ToChar(i + 65)}] | ");

                for (int j = 0; j < 5; j++)
                {
                    if (Coordinates[i, j] != null) Console.Write($"[{(int)Coordinates[i, j].GetColor()}]");
                    else Console.Write("   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("     ----------------\n");
        }

        /// <summary>
        /// Method to check if the inserted position has a piece
        /// </summary>
        /// <param name="posx">row</param>
        /// <param name="posy">column</param>
        /// <returns>Piece/null</returns>
        public Piece Coordinate(int posx, int posy)
        {
            return Coordinates[posx, posy];
        }
        
        /// <summary>
        /// Method to get the piece's color of the inserted coordinates
        /// </summary>
        /// <param name="posx">row</param>
        /// <param name="posy">column</param>
        /// <returns>Player.White, Player.Black, Player.None</returns>
        public Player CoordinateColor(int posx, int posy)
        {
            return Coordinates[posx, posy].GetColor();
        }

        /// <summary>
        /// Moves the selected piece to the desired position
        /// </summary>
        /// <param name="player">Current Player's Color</param>
        /// <param name="posx">Selected piece row</param>
        /// <param name="posy">Selected piece column</param>
        /// <param name="mposx">Desired position row</param>
        /// <param name="mposy">Desired position column</param>
        public void MovePiece(
            Player player, int posx, int posy, int mposx, int mposy)
        {
            Coordinates[posx, posy].SetColor(Player.None);
            Coordinates[mposx, mposy].SetColor(player);
        }

        /// <summary>
        /// Moves the selected piece to the desired position
        /// </summary>
        /// <param name="player">Current Player's color</param>
        /// <param name="posx">Selected piece row</param>
        /// <param name="posy">Selected piece column</param>
        /// <param name="mposx">Desired position row</param>
        /// <param name="mposy">Desired position column</param>
        public void MoveEatPiece(
            Player player, int posx, int posy, int mposx, int mposy)
        {
            Coordinates[posx, posy].SetColor(Player.None);
            Coordinates[posx + (mposx - posx) / 2, posy +
                (mposy - posy) / 2].SetColor(Player.None);
            Coordinates[mposx, mposy].SetColor(player);

            if (player == Player.Black) Piece.RemoveWPiece();
            else if (player == Player.White) Piece.RemoveBPiece();
        }

        /// <summary>
        /// Checks if both Players have pieces
        /// </summary>
        /// <param name="game"> GameBoard</param>
        /// <returns>true/false</returns>
        public bool Check(Board game)
        {
            if (Piece.GetBPieces() == 0)
            {
                winner = Player.White;
                return false;
            }

            if (Piece.GetWPieces() == 0)
            {
                winner = Player.Black;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get's the winner
        /// </summary>
        /// <returns>Player.Black/Player.White</returns>
        public static Player GetWinner()
        {
            return winner;
        }
    }
}