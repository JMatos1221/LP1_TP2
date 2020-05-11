using System;

namespace Felli
{
    public class Board
    {
        Piece[,] Coordinates = new Piece[5, 3];

        public Board()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Coordinates[i, j] = new Piece(Player.Black);
                }
            }

            this.Coordinates[2, 1] = new Piece(Player.None);

            for (int i = 3; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Coordinates[i, j] = new Piece(Player.White);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("      [1]   [2]   [3]");
            Console.WriteLine("     ----------------");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"[{Convert.ToChar(i + 65)}] | ");

                if (i == 1 | i == 3) Console.Write("   ");

                for (int j = 0; j < 3; j++)
                {
                    if (i == 0 | i == 4) Console.Write(
                         $"[{(int)Coordinates[i, j].GetColor()}]   ");
                    if (i == 1 | i == 3) Console.Write(
                         $"[{(int)Coordinates[i, j].GetColor()}]");
                    if (i == 2 & j == 1) Console.Write(
                         $"      [{(int)Coordinates[i, j].GetColor()}]");
                }
                Console.WriteLine();
            }
            Console.WriteLine("     ----------------\n");
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
                game.Print();
                Console.WriteLine("White wins!");
                return false;
            }

            if (Piece.GetWPieces() == 0)
            {
                game.Print();
                Console.WriteLine("Black wins!");
                return false;
            }

            return true;
        }
    }
}