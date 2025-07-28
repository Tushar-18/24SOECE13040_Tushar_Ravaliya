using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    internal class p11
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Name: "); string name = Console.ReadLine();


            Console.Write("Enter Gender (M/F): ");
            char gender = Convert.ToChar(Console.ReadLine()); if (gender == 'M' || gender == 'm')
                Console.WriteLine("Mr. " + name);
            else if (gender == 'F' || gender == 'f') Console.WriteLine("Ms. " + name);
            else
                Console.WriteLine("Invalid Gender"); Console.ReadLine();
        }

    }
}
