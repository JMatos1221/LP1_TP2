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

            for (int i = 0; i < 3; i++)
            {
                this.Coordinates[2, i] = new Piece(Player.None);
            }

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
            for (int i = 0; i < 5; i++)
            {
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


        }

        public void MovePiece(
            Player player, int posx, int posy, int mposx, int mposy)
        {
            Coordinates[posx, posy].SetColor(Player.None);
            Coordinates[mposx, mposy].SetColor(player);
        }
    }
}