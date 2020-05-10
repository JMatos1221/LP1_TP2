using System;

namespace Felli
{
    public class Piece
    {
        private Player color;

        public Piece(Player color)
        {
            this.color = color;
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