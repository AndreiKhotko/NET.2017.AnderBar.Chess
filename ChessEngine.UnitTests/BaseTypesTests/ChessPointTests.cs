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
            var chessPoint = new ChessPoint('a', 3) { Number = number};

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
    }
}
