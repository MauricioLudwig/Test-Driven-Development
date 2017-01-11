using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TDD_IO
{
    public class Runtime
    {
        private string firstName, lastName;
        private int num1, num2;
        private string textFilePath;

        public Runtime()
        {
            string textFile = "MyTextFile.txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            textFilePath = directory + "\\" + textFile;
            if (!(File.Exists(textFilePath)))
                File.Create(textFilePath);
        }

        public void Start()
        {
            GetValuesFromUser();

            string[] textFileArray = new string[]
            {
                NameConcatination(firstName, lastName),
                Add(num1, num2).ToString(),
                Substract(num1, num2).ToString(),
                Multiply(num1, num2).ToString(),
                Divide(num1, num2).ToString(),
            };

            WriteToTextFile(textFileArray, textFilePath);
        }

        public void GetValuesFromUser()
        {
            Console.WriteLine("Enter your first name: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name: ");
            lastName = Console.ReadLine();

            num1 = ValidInteger("Enter first number: ");
            num2 = ValidInteger("Enter second number: ");
        }

        public void WriteToTextFile(string[] textFileArray, string pathway)
        {
            File.WriteAllLines(pathway, textFileArray);
        }

        public int ValidInteger(string text)
        {
            bool validInput;
            string input;
            int output;

            while (true)
            {
                Console.WriteLine(text);
                input = Console.ReadLine();
                validInput = int.TryParse(input, out output);

                if (validInput)
                    return output;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!");
                    Console.ResetColor();
                }
            }
        }

        public string NameConcatination(string x, string y)
        {
            // return "Damien Gallagher";
            return String.Format(x + " " + y);
        }

        public int Add(int x, int y)
        {
            // return 3;
            return x + y;
        }

        public int Substract(int x, int y)
        {
            // return -6;
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            // return 0;
            return x * y;
        }

        public int? Divide(int x, int y)
        {
            // return 0
            if (!(y == 0))
                return x / y;
            else
                // return null
                return null;
        }
    }
}
