using System;

namespace Felli
{
    public class Piece
    {
        private Player color;
        private static int blackPieces = 0, whitePieces = 0;

        public Piece(Player color)
        {
            this.color = color;

            if(this.color == Player.Black) blackPieces +=1;

            if(this.color == Player.White) whitePieces +=1;
        }

        public Player GetColor()
        {
            return color;
        }

        public void SetColor(Player color)
        {
            this.color = color;
        }
    }
}