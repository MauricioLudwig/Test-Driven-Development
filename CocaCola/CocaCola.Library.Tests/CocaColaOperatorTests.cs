using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CocaCola.Library.Tests
{
    [TestFixture]
    public class CocaColaOperatorTests
    {

        [Test]
        public void Input1_Returns1()
        {
            var coca = new CocaColaOperator();

            // Arrange
            int input = 1;

            // Act
            string output = coca.StringOperator(input);

            // Assert
            Assert.AreEqual("1", output);
        }

        [Test]
        public void Input2_Returns2()
        {
            var coca = new CocaColaOperator();
            int input = 2;
            string output = coca.StringOperator(input);
            Assert.AreEqual("2", output);
        }

        [Test]
        public void IfDivisibleByThree(
            [Values(3, 6, 9, 12)] int input)
        {
            var coca = new CocaColaOperator();
            string output = coca.StringOperator(input);
            Assert.AreEqual("Coca", output);
        }

        [Test]
        public void IfDivisibleByFive(
            [Values(5, 10, 20, 25)] int input)
        {
            var coca = new CocaColaOperator();
            string output = coca.StringOperator(input);
            Assert.AreEqual("Cola", output);
        }

        [Test]
        public void IfDivisibleByThreeAndFive(
            [Values(15, 30, 45, 60)] int input)
        {
            var coca = new CocaColaOperator();
            string output = coca.StringOperator(input);
            Assert.AreEqual("CocaCola", output);
        }
    }
}
