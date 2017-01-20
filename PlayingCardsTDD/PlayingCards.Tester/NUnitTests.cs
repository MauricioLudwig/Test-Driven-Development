using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlayingCardsTDD;

namespace PlayingCards.Tester
{

    [TestFixture]
    public class NUnitTests
    {

        [Test, Sequential]
        public void InputStringReturnFormat(
            [Values("2d", "qs", "9D", "ah", "kc")] string input,
            [Values("Two of Diamonds", "Queen of Spades", "Nine of Diamonds", "Ace of Hearts", "King of Clubs")] string expectedResult)
        {
            Runtime runtime = new Runtime();

            string actualResult = runtime.InputOperation(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test, Sequential]
        public void InputIncorrectLengthReturnInvalidOutput(
            [Values("10dd", "a")] string input)
        {
            Runtime runtime = new Runtime();

            string expectedResult = "Invalid input...";
            string actualResult = runtime.InputOperation(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
