using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocaCola.Library;

namespace CocaCola
{
    class Runtime
    {
        public void Start()
        {
            var coca = new CocaColaOperator();

            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(coca.StringOperator(i));
            }
        }
    }
}
