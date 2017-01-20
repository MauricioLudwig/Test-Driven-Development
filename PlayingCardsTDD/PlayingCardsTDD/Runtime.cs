using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace PlayingCardsTDD
{
    public class Runtime
    {

        private List<Card> Suits;
        private List<Card> Values;
        private string LogFilePath;

        public Runtime()
        {

            #region List of Card Suits
            Suits = new List<Card>()
            {
                new Card { Key = "H", Value = "Hearts"   },
                new Card { Key = "D", Value = "Diamonds" },
                new Card { Key = "C", Value = "Clubs"    },
                new Card { Key = "S", Value = "Spades"   },
            };
            #endregion

            #region List of Card Values
            Values = new List<Card>()
            {
                new Card { Key = "A" , Value = "Ace"   },
                new Card { Key = "2" , Value = "Two"   },
                new Card { Key = "3" , Value = "Three" },
                new Card { Key = "4" , Value = "Four"  },
                new Card { Key = "5" , Value = "Five"  },
                new Card { Key = "6" , Value = "Six"   },
                new Card { Key = "7" , Value = "Seven" },
                new Card { Key = "8" , Value = "Eight" },
                new Card { Key = "9" , Value = "Nine"  },
                new Card { Key = "T",  Value = "Ten"   },
                new Card { Key = "J" , Value = "Jack"  },
                new Card { Key = "Q" , Value = "Queen" },
                new Card { Key = "K" , Value = "King"  },
            };
            #endregion

            LogFilePath = String.Format(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\log_file.txt");

            if (!(File.Exists(LogFilePath)))
                File.Create(LogFilePath).Close();
        }

        public void Start()
        {

            bool loop = true;

            while (loop)
            {
                UI.MainMenu();
                var choice = Console.ReadKey(true).Key;
                UI.LineBreak();

                switch (choice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        InputCommand();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ModuleTesting();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Bye!");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input...");
                        break;
                }

                Console.Clear();
            }
        }

        public void InputCommand()
        {
            Console.Write("Input command: ");
            string input = Console.ReadLine();
            string output = InputOperation(input);
            Console.WriteLine(output);
            Console.ReadKey();
        }

        public string InputOperation(string input)
        {
            input = input.ToUpper().Replace(" ", String.Empty);
            string output = String.Empty;

            if (input.Length == 2 || input.Contains("10") && input.Length == 3)
            {

                if (input.Length == 3 && input.Contains("10"))
                    input = input.Replace("10", "T");

                bool validValue = Values
                    .Exists(v => v.Key.Contains(input[0].ToString()));
                bool validSuit = Suits
                    .Exists(s => s.Key.Contains(input[1].ToString()));

                if (validValue && validSuit)
                {
                    output += Values
                        .FirstOrDefault(v => v.Key.Contains(input[0].ToString()))
                        .Value;

                    output += " of ";

                    output += Suits
                        .FirstOrDefault(s => s.Key.Contains(input[1].ToString()))
                        .Value;
                }
                else
                    output = "Invalid input...";
            }
            else
                output = "Invalid input...";

            return output;
        }

        public void ModuleTesting()
        {
            int index = 1;
            int testPass = 0;
            int testFail = 0;
            string logRow;
            string expectedResult;
            string actualResult;

            List<string> log = new List<string>();

            foreach (var value in Values)
            {                              
                foreach (var suit in Suits)
                {
                    logRow = String.Empty;

                    expectedResult = value.Value + " of " + suit.Value;
                    actualResult = InputOperation(value.Key + suit.Key);

                    logRow += String.Format("{0} | Input: {1,-10}Expected: {2,-30}Result: {3,-30}",
                        index.ToString("D3"),
                        value.Key + suit.Key,
                        value.Value + " of " + suit.Value,
                        actualResult,
                        "");

                    if (String.Equals(expectedResult, actualResult))
                    {
                        logRow += "PASS";
                        testPass++;
                    }
                    else
                    {
                        logRow += "FAIL";
                        testFail++;
                    }

                    log.Add(logRow);
                    index++;
                }                               
            }

            File.WriteAllLines(LogFilePath, log);
            Console.WriteLine("Log file registered.");
            Console.Write("Test results: {0} Pass, {1} Fail", testPass, testFail);
            UI.LineBreak();
            Console.Write("Press enter to launch text file...");
            Console.ReadKey();
            Process.Start(LogFilePath);
        }
    }
}
