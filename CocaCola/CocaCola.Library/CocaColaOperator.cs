using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocaCola.Library
{
    public class CocaColaOperator
    {
        public string StringOperator(int input)
        {
            // Attempt 1
            // return String.Empty;

            // Attempt 2
            // return "1";

            // Attempt 3
            // return input.ToString();

            #region Attempt 4
            /*
            if (input % 3 == 0)
                return "Coca";
            else
                return input.ToString();
            */
            #endregion

            #region Attempt 5
            /*
            if (input % 3 == 0)
                return "Coca";
            else if (input % 5 == 0)
                return "Cola";
            else
                return input.ToString();
            */
            #endregion

            #region Attempt 6 + Refactor
            if (input % 3 == 0 && input % 5 == 0)
                return "CocaCola";
            else if (input % 3 == 0)
                return "Coca";
            else if (input % 5 == 0)
                return "Cola";
            else
                return input.ToString();
            #endregion
        }
    }
}
