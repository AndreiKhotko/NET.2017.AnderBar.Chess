using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessEngine.BaseTypes;

namespace ChessEngine.Pieces
{
    public abstract class Piece
    {
        public ChessPoint Coordinate { get; set; }

        public Color Color { get; }

        protected Piece(ChessPoint coordinate, Color color)
        {
            Coordinate = coordinate;
            Color = color;
        }
    }
}
