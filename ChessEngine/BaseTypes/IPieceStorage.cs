using System.Collections.Generic;
using ChessEngine.Pieces;

namespace ChessEngine.BaseTypes
{
    /// <summary>
    /// An interface for a storage for pieces, which is used in ChessBoard class
    /// </summary>
    public interface IPieceStorage
    {
        /// <summary>
        /// Add a single piece to storage
        /// </summary>
        /// <param name="piece">An instance of Piece child to be added</param>
        void AddPiece(Piece piece);

        /// <summary>
        /// Remove a single piece from storage
        /// </summary>
        /// <param name="piece">An instance of Piece child to be removed</param>
        void RemovePiece(Piece piece);

        /// <summary>
        /// Add a range of pieces to storage
        /// </summary>
        /// <param name="pieces">Collection of pieces</param>
        void AddRange(ICollection<Piece> pieces);

        /// <summary>
        /// Change the position of piece in storage
        /// </summary>
        /// <param name="piece">An instance of Piece child</param>
        /// <param name="newPosition">A new position of piece</param>
        void ChangePosition(Piece piece, ChessPoint newPosition);

        /// <summary>
        /// Get an instance of Piece using a position on chessboard
        /// </summary>
        /// <param name="position">A position of piece which we want to get</param>
        /// <returns>An instance of Piece on this position</returns>
        Piece GetPiece(ChessPoint position);

        /// <summary>
        /// Clear storage
        /// </summary>
        void Clear();
    }
}
