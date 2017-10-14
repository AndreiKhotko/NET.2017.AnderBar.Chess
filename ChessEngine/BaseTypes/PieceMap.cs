using System;
using System.Collections.Generic;
using ChessEngine.Exceptions;
using ChessEngine.Pieces;

namespace ChessEngine.BaseTypes
{
    public class PieceMap : IPieceStorage
    {
        /// <summary>
        /// Private array for storing pieces
        /// </summary>
        private readonly Piece[][] _map;

        /// <summary>
        /// A structure transform chess coordinates to indexes for storing in _map field 
        /// </summary>
        private struct MappedCoordinates
        {
            public int X { get; }
            public int Y { get; }

            public MappedCoordinates(ChessPoint coordinate)
            {
                X = coordinate.Letter - 'a';
                Y = coordinate.Number - 1;
            }
        }

        public PieceMap()
        {
            _map = new Piece[8][]
            {
                new Piece[8],
                new Piece[8],
                new Piece[8],
                new Piece[8],
                new Piece[8],
                new Piece[8],
                new Piece[8],
                new Piece[8]
            };
        }
        
        public void AddPiece(Piece piece)
        {
            if (ReferenceEquals(piece, null))
                throw new ArgumentNullException(nameof(piece));

            var coordinates = new MappedCoordinates(piece.Coordinate);

            if (!ReferenceEquals(_map[coordinates.X][coordinates.Y], null))
                throw new BusyCellException("Can't add piece to piecemap: the cell with coodinates " +
                                            $"{piece.Coordinate.Letter}{piece.Coordinate.Number} ({coordinates.X}, {coordinates.Y}) is busy.");

            _map[coordinates.X][coordinates.Y] = piece;
        }

        public void RemovePiece(Piece piece)
        {
            if (ReferenceEquals(piece, null))
                throw new ArgumentNullException(nameof(piece));

            var coordinates = new MappedCoordinates(piece.Coordinate);
            _map[coordinates.X][coordinates.Y] = null;
        }

        public void AddRange(ICollection<Piece> pieces)
        {
            if (ReferenceEquals(pieces, null))
                throw new ArgumentNullException(nameof(pieces));

            foreach (var piece in pieces)
            {
                AddPiece(piece);
            }
        }

        public void ChangePosition(Piece piece, ChessPoint newPosition)
        {
            if (ReferenceEquals(piece, null))
                throw new ArgumentNullException(nameof(piece));

            if (ReferenceEquals(newPosition, null))
                throw new ArgumentNullException(nameof(newPosition));

            var oldCoordinates = new MappedCoordinates(piece.Coordinate);
            var newCoordinates = new MappedCoordinates(newPosition);

            if (!ReferenceEquals(_map[newCoordinates.X][newCoordinates.Y], null))
                throw new BusyCellException("Can't change piece position: the cell with coodinates " +
                                            $"{newPosition.Letter}{newPosition.Number} ({newCoordinates.X}, {newCoordinates.Y}) is busy.");

            _map[newCoordinates.X][newCoordinates.Y] = piece;
            _map[oldCoordinates.X][oldCoordinates.Y] = null;

            piece.Coordinate.Letter = newPosition.Letter;
            piece.Coordinate.Number = newPosition.Number;
        }

        public Piece GetPiece(ChessPoint cell)
        {
            var mapCoordinates = new MappedCoordinates(cell);

            return _map[mapCoordinates.X][mapCoordinates.Y];
        }

        public void Clear()
        {
            for (var i = 0; i < 8; i++)
            for (var j = 0; j < 8; j++)
                _map[i][j] = null;
        }
    }
}
