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
        static string result;

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

                bool validSequence = true;

                stringInput = Console.ReadLine().ToUpper();
                validInput = int.TryParse(stringInput, out integerInput);

                try
                {
                    ValidateNumeralSequence(stringInput);
                }
                catch (NonValidSequence e)
                {
                    Console.WriteLine("{0}. Input is not in a valid sequence.", e.Message);
                    validSequence = false;
                }

                if (stringInput == "0")
                    Console.WriteLine("The latin equivalence of 0 is 'nulla'");
                else if (!(String.IsNullOrEmpty(stringInput)) && validSequence == true)
                {

                    if (validInput)
                    {
                        try
                        {
                            AllowedNumbers(integerInput, stringInput);
                        }
                        catch (InvalidNumberException e)
                        {
                            Console.WriteLine(e.Message + ": Only numbers between 0 - 4999 allowed.");
                        }
                    }
                    else
                    {
                        try
                        {
                            if (stringInput.All(c => Enum.IsDefined(typeof(RomanNumeralsType), c.ToString())))
                            {
                                result = String.Format("{0} = {1}", stringInput, converter.ConvertToInteger(stringInput).ToString());
                                Console.WriteLine(result);
                            }
                            else
                                throw new NonValidNumeralException();
                        }
                        catch (NonValidNumeralException e)
                        {
                            Console.WriteLine("NonValidNumeralException thrown: {0} is not a valid Roman Numeral.", stringInput);
                        }
                    }
                }
                else if (String.IsNullOrEmpty(stringInput))
                    Console.WriteLine("No empty strings are allowed.");

                Console.Write("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void AllowedNumbers(int input, string stringInput)
        {
            if (input > 0 && input <= 4999)
            {
                result = String.Format("{0} = {1}", stringInput, converter.ConvertToRomanNumeral(input));
                Console.WriteLine(result);
            }
            else
                throw new InvalidNumberException("InvalidNumberException thrown");
        }

        public static void ValidateNumeralSequence(string input)
        {

            bool validSequence = true;

            string[] myArray = new string[] { input };
            string[] nonAllowedNumeralSequence = new string[]
            {
                "DM", "LM", "IM", "XM", "VM", "LD", "XD", "VD", "ID", "IIII", "LC", "VC",
                "IC", "VL", "IL", "LL",
            };

            foreach (var seq in nonAllowedNumeralSequence)
            {
                if (myArray[0].Contains(seq))
                    validSequence = false;
            }

            if (!validSequence)
                throw new NonValidSequence("NonValidSequence thrown");
        }

    }
}
