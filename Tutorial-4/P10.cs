using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_4
{
    internal class P10
    {
        class MyException : Exception
        {
            /// <summary>
            /// Constructor that takes a message string and passes it to the base Exception class.
            /// This ensures the message is stored in the exception object.
            /// </summary>
            /// <param name="str">The exception message.</param>
            public MyException(string str) : base(str)
            {
            }
        }
     
           
            public static void Main()
            {
                try
                {
                    
                    throw new MyException("my exception generated.");
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine("Exception caught here: " + e.Message);
                }

                
                Console.WriteLine("LAST STATEMENT");
            
        }
    }
}
