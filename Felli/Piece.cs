using System;

namespace Felli
{
    public class Piece
    {
        /// <summary>
        /// Declared variables
        /// </summary>
        private Player color;
        private static int blackPieces = 0, whitePieces = 0;

        /// <summary>
        /// Piece constructor
        /// </summary>
        /// <param name="color">Piece owner</param>
        public Piece(Player color)
        {
            this.color = color;

            if (this.color == Player.Black) blackPieces += 1;

            if (this.color == Player.White) whitePieces += 1;
        }

        /// <summary>
        /// Gets the piece color/owner
        /// </summary>
        /// <returns>Player.White/Player.Black/Player.None</returns>
        public Player GetColor()
        {
            return color;
        }

        /// <summary>
        /// Changes the Piece color/owner
        /// </summary>
        /// <param name="color">Player.White/Player.Black/Player.None</param>
        public void SetColor(Player color)
        {
            this.color = color;
        }

        /// <summary>
        /// Gets the number of black Pieces
        /// </summary>
        /// <returns>Number of black Pieces</returns>
        public static int GetBPieces()
        {
            return blackPieces;
        }

        /// <summary>
        /// Gets the number of white Pieces
        /// </summary>
        /// <returns>Number of white Pieces</returns>
        public static int GetWPieces()
        {
            return whitePieces;
        }

        /// <summary>
        /// Subtracts one from the blackPieces static variable
        /// </summary>
        public static void RemoveBPiece()
        {
            blackPieces -= 1;
        }

        /// <summary>
        /// Subtracts one from the whitePieces static variable
        /// </summary>
        public static void RemoveWPiece()
        {
            whitePieces -= 1;
        }
    }
}