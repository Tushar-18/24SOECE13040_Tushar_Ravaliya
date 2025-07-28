using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    internal class p8
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            string upperName = name.ToUpper(); 
            Console.WriteLine("Name in Uppercase: " + upperName);
            Console.ReadLine();
        }

    }
}
