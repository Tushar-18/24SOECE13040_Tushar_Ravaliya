using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    internal class p21
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of terms: "); int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int term = 0; int sum = 0;

            Console.WriteLine(); Console.Write("Series: ");
            for (int i = 1; i <= n; i++)
            {
                term = term * 10 + num; Console.Write(term);
                if (i != n) Console.Write(" + ");
                sum += term;
            }

            Console.WriteLine("\n\nThe Sum is : " + sum); Console.ReadLine();
        }

    }
}
