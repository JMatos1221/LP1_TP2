using System;

namespace Felli
{
    public class Board
    {
        Piece[,] Coordinates = new Piece[5, 5];
        static Player winner;

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

        public Piece Coordinate(int posx, int posy)
        {
            return Coordinates[posx, posy];
        }

        public Player CoordinateColor(int posx, int posy)
        {
            return Coordinates[posx, posy].GetColor();
        }

        public void MovePiece(
            Player player, int posx, int posy, int mposx, int mposy)
        {
            Coordinates[posx, posy].SetColor(Player.None);
            Coordinates[mposx, mposy].SetColor(player);
        }
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

        public static Player GetWinner()
        {
            return winner;
        }
    }
}