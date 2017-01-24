using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    [Serializable]
    public class UserDefinedException : Exception
    {
        public UserDefinedException() : base()
        {

        }

        public UserDefinedException(string message) : base(message)
        {

        }

        public UserDefinedException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
