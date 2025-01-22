using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eexamm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 32;
            long result = CalculateS(n);
            Console.WriteLine($"S({n}) = {result}");
            Console.ReadKey();
        }

        static long CalculateS(int n)
        {

            long[] M = new long[n + 1];

            M[1] = 2;
            if (n >= 2)
            {
                M[2] = 6;
            }

            for (int i = 3; i <= n; i++)
            {
                M[i] = M[i - 1] * 2 + 2 * (i - 1);
            }

            return M[n];
        }
    }
}
