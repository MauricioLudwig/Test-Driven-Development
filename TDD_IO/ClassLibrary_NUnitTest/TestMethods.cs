using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD_IO;
using System.IO;

namespace ClassLibrary_NUnitTest
{
    [TestFixture]
    public class TestMethods
    {

        Runtime runtime = new Runtime();

        [Test]
        public void ValidateFile()
        {
            bool expectedResult = true;

            string textFile = "MyTextFile.txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string textFilePath = directory + "\\" + textFile;

            bool actualResult = File.Exists(textFilePath);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateName(
            [Values("Franz", "Damien")] string firstName,
            [Values("Kafka", "Gallagher")] string lastName)
        {
            string expectedResult = firstName + " " + lastName;
            string actualResult = runtime.NameConcatination(firstName, lastName);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateAddition(
            [Values(1, 0)] int x,
            [Values(2, 7)] int y)
        {
            int expectedResult = x + y;
            int actualResult = runtime.Add(x, y);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateSubstraction(
            [Values(-1, 10)] int x,
            [Values(5, 60)] int y)
        {
            int expectedResult = x - y;
            int actualResult = runtime.Substract(x, y);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateMultiplication(
            [Values(-10, 6)] int x,
            [Values(0, 22)] int y)
        {
            int expectedResult = x * y;
            int actualResult = runtime.Multiply(x, y);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateDivision(
            [Values(0, 1)] int x,
            [Values(2 ,1)] int y)
        {
            int expectedResult = x / y;
            int? actualResult = runtime.Divide(x, y);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DivisionByZero()
        {
            int x = 1;
            int y = 0;
            int? expectedResult = null;
            int? actualResult = runtime.Divide(x, y);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ValidateReadAndWrite(
            [Values(8, 2)] int x,
            [Values(0, -5)] int y,
            [Values("Damien", "Franz")] string firstName,
            [Values("Gallagher", "Kafka")] string lastName)
        {

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string pathway = directory + "\\" + "TextFile_Test.txt";

            string[] expectedResult = new string[]
            {
                runtime.NameConcatination(firstName, lastName),
                runtime.Add(x, y).ToString(),
                runtime.Substract(x, y).ToString(),
                runtime.Multiply(x, y).ToString(),
                runtime.Divide(x, y).ToString(),
            };

            runtime.WriteToTextFile(expectedResult, pathway);

            string[] actualResult = File.ReadAllLines(pathway);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(actualResult[i], expectedResult[i]);
            }
        }

    }
}
