using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    public class NonValidNumeralException : Exception
    {
        public NonValidNumeralException() : base()
        {

        }

        public NonValidNumeralException(string message) : base(message)
        {

        }

        public NonValidNumeralException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
