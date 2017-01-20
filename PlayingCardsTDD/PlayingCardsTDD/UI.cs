using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsTDD
{
    class UI
    {

        public static void MainMenu()
        {
            Console.WriteLine("1. Input command");
            Console.WriteLine("2. Module Testing");
            Console.WriteLine("3. Exit Program");

            Console.WriteLine("\n{0}\n{1}\n{2}\n{3}\n",
                "h/h = Hearts", "d/D = Diamonds", "c,C = Clubs", "s/S = Spades");

            Console.Write("Menu selection: ");
        }

        public static void LineBreak()
        {
            Console.WriteLine("\n\n---------------------------------\n");
        }
    }
}
