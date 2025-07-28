using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    internal class p20
    {
        static void Main(string[] args)
        {
            int rows = 4; int num = 1;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++)

                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(num + " "); num++;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}
