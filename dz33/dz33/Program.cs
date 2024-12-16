using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите четырехзначное число: ");
            int chislo = int.Parse(Console.ReadLine());

            var ch1 = chislo % 10;
            chislo /= 10;
            var ch2 = chislo % 10;
            chislo /= 10;
            var ch3 = chislo % 10;
            chislo /= 10;
            var ch4 = chislo % 10;
            chislo /= 10;

            Console.WriteLine("Инверсированное число = " + ch1 + ch2 + ch3 + ch4);


            Console.ReadKey();
        }
    }
}