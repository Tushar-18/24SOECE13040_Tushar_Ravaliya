using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    internal class p9
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: "); string name = Console.ReadLine(); string result = "";
            foreach (char ch in name)
            {
                if (char.IsUpper(ch))
                    result += char.ToLower(ch);
                else
                    result += char.ToUpper(ch);

            }
            Console.WriteLine("Toggle Case Name: " + result); Console.ReadLine();
        }

    }
}
