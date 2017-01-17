using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    public class Program
    {

        static RomanNumeralConverter converter;

        static void Main(string[] args)
        {
            converter = new RomanNumeralConverter();
            Run();
        }
        
        public static void Run()
        {

            // Instance variables
            string stringInput;
            bool validInput;
            int integerInput;
            string result;

            while (true)
            {
                #region Menu
                Console.WriteLine("Numeral Registry");
                Console.WriteLine("M  - 1000");
                Console.WriteLine("D  - 500");
                Console.WriteLine("C  - 100");
                Console.WriteLine("L  - 50");
                Console.WriteLine("X  - 10");
                Console.WriteLine("V  - 5");
                Console.WriteLine("I  - 1\n");
                Console.WriteLine("Please enter an integer value OR roman numeral to be converted...");
                #endregion

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nInput: ");
                Console.ResetColor();

                stringInput = Console.ReadLine().ToUpper();
                validInput = int.TryParse(stringInput, out integerInput);

                if (!(String.IsNullOrEmpty(stringInput)))
                {

                    if (validInput)
                    {
                        // if string is a valid integer input
                        result = String.Format("{0} = {1}", stringInput, converter.ConvertToRomanNumeral(integerInput));
                    } 
                    else
                    {
                        // if string is not a valid integer input
                        // if string is defined in the Roman Numeral enum list
                        if (stringInput.All(c => Enum.IsDefined(typeof(RomanNumeralsType), c.ToString())))
                        {
                            result = String.Format("{0} = {1}", stringInput, converter.ConvertToInteger(stringInput).ToString());
                        }
                        // if string is not defined in the Roman Numeral enum list
                        else
                            result = String.Format("{0} is an invalid input, try again...", stringInput);
                    }

                    Console.WriteLine(result);
                }
                else
                    Console.WriteLine("No empty strings are allowed.");

                Console.Write("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
