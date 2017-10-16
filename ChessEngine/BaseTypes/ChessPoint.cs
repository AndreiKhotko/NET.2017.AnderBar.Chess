using System;

namespace ChessEngine.BaseTypes
{
    /// <summary>
    /// Class represents a chess point
    /// </summary>
    public class ChessPoint : IEquatable<ChessPoint>
    {
        public int Number
        {
            get { return _number; }
            set
            {
                if (!IsCorrectNumber(value))
                    throw new ArgumentException($"Number {value} is not between 1 and 8.");

                _number = value;
            }
        }

        public char Letter
        {
            get { return _letter; }
            set
            {
                if (!IsCorrectLetter(value))
                    throw new ArgumentException($"Letter {value} is not between a and h.");

                _letter = char.ToLower(value);
            }
        }

        /// <summary>
        /// A private field for property Number
        /// </summary>
        private int _number;
        /// <summary>
        /// A private field for property Letter
        /// </summary>
        private char _letter;

        /// <summary>
        /// Single constructor with two parameters
        /// </summary>
        /// <param name="letter">Alphabetic part of chess point</param>
        /// <param name="number">Numeric part of chess point</param>
        public ChessPoint(char letter, int number)
        {
            Number = number;
            Letter = letter;
        }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as ChessPoint);
        }

        public bool Equals(ChessPoint point)
        {
            return point != null && point.Letter == this.Letter && point.Number == this.Number;
        }

        public static bool operator !=(ChessPoint point1, ChessPoint point2)
        {
            if (!ReferenceEquals(point1, null))
                return !(point1.Equals(point2));

            return !ReferenceEquals(point2, null);
        }

        public static bool operator ==(ChessPoint point1, ChessPoint point2)
        {
            if (!ReferenceEquals(point1, null))
                return point1.Equals(point2);

            return ReferenceEquals(point2, null);
        }

        public override int GetHashCode()
        {
            return Letter.GetHashCode() ^ Number.GetHashCode();
        }

        /// <summary>
        /// A private validator of char parameter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>True if char parameter is a valid for chess point</returns>
        private static bool IsCorrectLetter(char letter)
        {
            return (letter >= 'a' && letter <= 'h') || (letter >= 'A' && letter <= 'H');
        }

        /// <summary>
        /// A private validator of int param
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True if number is a valid for chess point</returns>
        private static bool IsCorrectNumber(int number)
        {
            return number >= 1 && number <= 8;
        }
    }
}
