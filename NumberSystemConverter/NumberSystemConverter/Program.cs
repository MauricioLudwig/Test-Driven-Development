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

                try
                {
                    stringInput = Console.ReadLine().ToUpper();
                }
                catch (Exception e)
                {
                    if (e is OutOfMemoryException || e is ArgumentOutOfRangeException || e is System.IO.IOException)
                        throw new UserDefinedException("Error encountered: " + e.Message);
                    stringInput = String.Empty;
                }

                validInput = int.TryParse(stringInput, out integerInput);

                try
                {
                    if (String.IsNullOrEmpty(stringInput))
                        throw new UserDefinedException();
                }
                catch (Exception e)
                {
                    if (e is UserDefinedException)
                        Console.WriteLine("Error encountered: {0}. No empty strings allowed.",
                            e.Message);
                }

                try
                {
                    ValidateSequence(stringInput);
                }
                catch (Exception e)
                {
                    stringInput = string.Empty;
                    if (e is UserDefinedException)
                        Console.WriteLine("Error encountered: {0} Roman Numeral sequence was incorrect", e.Message);
                }
               
                if (!(String.IsNullOrEmpty(stringInput)))
                {  
                    if (validInput)
                    {
                        result = String.Format("{0} = {1}", stringInput, converter.ConvertToRomanNumeral(integerInput));
                    }
                    else
                    {
                        try
                        {
                            if (stringInput.All(c => Enum.IsDefined(typeof(RomanNumeralsType), c.ToString())))
                            {
                                result = String.Format("{0} = {1}", stringInput, converter.ConvertToInteger(stringInput).ToString());
                            }
                            else
                                throw new UserDefinedException();
                        }
                        catch (Exception e)
                        {
                            if (e is UserDefinedException)
                                Console.WriteLine("Error encountered: " + e.Message + " Write either all numerals or digits.");
                        }
                    }
                }

                Console.Write("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ValidateSequence(string input)
        {

            bool validSequence = true;

            string[] myArray = new string[] { input };
            string[] allowedRomanNumeralSequence = new string[]
            {
                "DM", "LM", "IM", "XM", "VM", "LD", "XD", "VD", "ID", "IIII", "LC", "VC",
                "IC", "VL", "IL",
            };

            foreach (var seq in allowedRomanNumeralSequence)
            {
                if (myArray[0].Contains(seq))
                    validSequence = false;
            }

            if (!validSequence)
                throw new UserDefinedException();
        }

    }
}
