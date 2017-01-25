using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    public class InvalidNumberException : Exception
    {
        
        public InvalidNumberException() : base()
        {

        }

        public InvalidNumberException(string message) : base(message)
        {

        }

        public InvalidNumberException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
