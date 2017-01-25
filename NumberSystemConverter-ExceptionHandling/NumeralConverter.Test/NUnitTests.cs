using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NumberSystemConverter;

namespace NumeralConverter.Test
{
    [TestFixture]
    public class NUnitTests
    {

        private RomanNumeralConverter converter;

        [Test, Sequential]
        public void InputIntegersReturnCorrectString(
            [Values(4, 9, 14, 19)] int input,
            [Values("IV", "IX", "XIV", "XIX")] string expectedResult)
        {
            converter = new RomanNumeralConverter();

            string actualResult = converter.ConvertToRomanNumeral(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Input0ReturnNulla()
        {
            converter = new RomanNumeralConverter();

            int input = 0;
            string expectedResult = "nulla";
            string actualResult = converter.ConvertToRomanNumeral(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test, Sequential]
        public void InputRomanNumeralReturnCorrectInteger(
            [Values("XXXVIII", "LXXXIX", "LXXXI", "XLVIII", "LXIV")] string input,
            [Values(38, 89, 81, 48, 64)] int expectedResult)
        {
            converter = new RomanNumeralConverter();
            int actualResult = converter.ConvertToInteger(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
