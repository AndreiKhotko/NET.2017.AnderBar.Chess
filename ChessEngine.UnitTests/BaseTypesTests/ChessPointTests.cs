using System;
using ChessEngine.BaseTypes;
using NUnit.Framework;

namespace ChessEngine.UnitTests.BaseTypesTests
{
    public class ChessPointTests
    {
        [TestCase('a', 1)]
        [TestCase('h', 1)]
        [TestCase('a', 8)]
        [TestCase('h', 8)]
        public void Ctor_TakesValidParameters_ShouldSetNumberAndValue(char letter, int number)
        {
            var chessPoint = new ChessPoint(letter, number);

            Assert.AreEqual(letter, chessPoint.Letter);
            Assert.AreEqual(number, chessPoint.Number);
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('h')]
        public void SetLetter_TakesValidLetter_ShouldSetLetter(char letter)
        {
            var chessPoint = new ChessPoint('c', 1) {Letter = letter};

            Assert.AreEqual(letter, chessPoint.Letter);
        }

        [TestCase('0')]
        [TestCase('*')]
        [TestCase('а')] // Russian letter a
        public void SetLetter_TakesNotValidLetter_ThrowsArgumentException(char letter)
        {
            var chessPoint = new ChessPoint('c', 1);

            Assert.Throws<ArgumentException>(() => { chessPoint.Letter = letter; });
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(8)]
        public void SetNumber_TakesValidNumber_ShouldSetNumber(int number)
        {
            var chessPoint = new ChessPoint('a', 3) {Number = number};

            Assert.AreEqual(number, chessPoint.Number);
        }

        [TestCase(0)]
        [TestCase(9)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void SetNumber_TakesNotValidNumber_ThrowsArgumentException(int number)
        {
            var chessPoint = new ChessPoint('a', 3);

            Assert.Throws<ArgumentException>(() => { chessPoint.Number = number; });
        }

        [TestCase('a', 1, 'a', 1)]
        [TestCase('h', 3, 'h', 3)]
        public void Equals_TakesEqualInstance_ReturnsTrue(char letter1, int number1, char letter2, int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.True(chessPoint1.Equals(chessPoint2));
        }

        [TestCase('a', 1, 'a', 2)]
        [TestCase('h', 3, 'b', 3)]
        public void Equals_TakesNonEqualInstance_ReturnsFalse(char letter1, int number1, char letter2, int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.False(chessPoint1.Equals(chessPoint2));
        }

        [TestCase('a', 1)]
        public void Equals_TakesNull_ReturnsFalse(char letter, int number)
        {
            var chessPoint = new ChessPoint(letter, number);

            Assert.False(chessPoint.Equals(null));
        }

        [TestCase('a', 1, 'a', 1)]
        [TestCase('h', 3, 'h', 3)]
        public void OverloadedEqualsOperator_TakesEqualInstances_ReturnsTrue(char letter1, int number1, char letter2,
            int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.True(chessPoint1 == chessPoint2);
        }

        [TestCase('a', 1, 'a', 2)]
        [TestCase('h', 3, 'b', 3)]
        public void OverloadedEqualsOperator_TakesNonEqualInstances_ReturnsFalse(char letter1, int number1, char letter2,
            int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.False(chessPoint1 == chessPoint2);
        }

        public void OverloadedEqualsOperator_TakesNulls_ReturnsTrue()
        {
            ChessPoint chessPoint1 = null;
            ChessPoint chessPoint2 = null;

            Assert.True(chessPoint1 == chessPoint2);
        }

        [TestCase('a', 1, 'a', 1)]
        [TestCase('h', 3, 'h', 3)]
        public void OverloadedNotEqualsOperator_TakesEqualInstances_ReturnsFalse(char letter1, int number1, char letter2,
            int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.False(chessPoint1 != chessPoint2);
        }

        [TestCase('a', 1, 'a', 2)]
        [TestCase('h', 3, 'b', 3)]
        public void OverloadedNotEqualsOperator_TakesNonEqualInstances_ReturnsTrue(char letter1, int number1, char letter2,
            int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.True(chessPoint1 != chessPoint2);
        }

        public void OverloadedNotEqualsOperator_TakesNulls_ReturnsFalse()
        {
            ChessPoint chessPoint1 = null;
            ChessPoint chessPoint2 = null;

            Assert.False(chessPoint1 == chessPoint2);
        }

        [TestCase('a', 1, 'a', 1)]
        [TestCase('d', 4, 'd', 4)]
        [TestCase('h', 8, 'h', 8)]
        public void GetHashCode_TwoEqualsInstances_ReturnsTrue(char letter1, int number1, char letter2, int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.True(chessPoint1.GetHashCode() == chessPoint2.GetHashCode());
        }

        [TestCase('a', 1, 'a', 2)]
        [TestCase('d', 4, 'c', 4)]
        public void GetHashCode_TwoNonEqualsInstances_ReturnsFalse(char letter1, int number1, char letter2, int number2)
        {
            var chessPoint1 = new ChessPoint(letter1, number1);
            var chessPoint2 = new ChessPoint(letter2, number2);

            Assert.False(chessPoint1.GetHashCode() == chessPoint2.GetHashCode());
        }
    }
}
