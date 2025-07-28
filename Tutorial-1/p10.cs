using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    internal class p10
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Mobile Number: "); string mobile = Console.ReadLine();
            string masked = mobile.Substring(0, mobile.Length - 5) + "XXXXX";


            Console.WriteLine("Masked Mobile Number: " + masked); Console.ReadLine();
        }

    }
}
