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

        public override bool Equals(object obj)
        {
            return Equals(obj as Piece);
        }

        public bool Equals(Piece piece)
        {
            return piece != null && piece.Color == this.Color && piece.Coordinate == this.Coordinate;
        }

        public override int GetHashCode()
        {
            if (Coordinate != null)
                return Coordinate.GetHashCode() ^ Color.GetHashCode();

            return Color.GetHashCode();
        }
    }
}
