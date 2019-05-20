using System;
using AlphaBank.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlphaBankTest.Client
{
    [TestClass]
    public class CardTests
    {
        private Card _card;

        [TestMethod]
        public void ValidPinReturnsTrue()
        {
            //Arrange
            _card = new Card(123123132132, "Jane Doe", DateTime.UtcNow.AddYears(2), 6789);

            //Act
            var isValidPin = _card.IsValidPin(6789);

            //Assert
            Assert.IsTrue(isValidPin);
        }


        [TestMethod]
        public void InValidPinReturnsFalse()
        {
            //Arrange
            _card = new Card(123123132132, "Jane Doe", DateTime.UtcNow.AddYears(2), 6789);

            //Act
            var isValidPin = _card.IsValidPin(1234);

            //Assert
            Assert.IsFalse(isValidPin);
        }
    }
}
