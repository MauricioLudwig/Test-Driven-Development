using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    [Serializable]
    public class NonValidSequence : Exception
    {
        public NonValidSequence() : base()
        {

        }

        public NonValidSequence(string message) : base(message)
        {

        }

        public NonValidSequence(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
