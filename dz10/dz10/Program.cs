using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        //zad6
        Console.Write("Введите количество работников (n): ");
        int numberOfWorkers = int.Parse(Console.ReadLine());
        const int numberOfMonths = 3;

        string[] workerNames = new string[numberOfWorkers];
        decimal[,] salaries = new decimal[numberOfWorkers, numberOfMonths];

        for (int i = 0; i < numberOfWorkers; i++)
        {
            workerNames[i] = "Работник " + (i + 1);

            Console.WriteLine($"Введите зарплату для {workerNames[i]} за каждый месяц:");
            for (int j = 0; j < numberOfMonths; j++)
            {
                Console.Write($"Месяц {j + 1}: ");
                salaries[i, j] = decimal.Parse(Console.ReadLine());
            }
        }


        for (int i = 0; i < numberOfWorkers; i++)
        {
            decimal maxSalary = salaries[i, 0];
            int monthIndex = 0;

            for (int j = 1; j < numberOfMonths; j++)
            {
                if (salaries[i, j] > maxSalary)
                {
                    maxSalary = salaries[i, j];
                    monthIndex = j;
                }
            }

            Console.WriteLine($"{workerNames[i]} получил наибольшую зарплату в месяце {monthIndex + 1} ({maxSalary:C}).");
        }


        for (int j = 0; j < numberOfMonths; j++)
        {
            decimal maxSalary = salaries[0, j];
            string topWorker = workerNames[0];

            for (int i = 1; i < numberOfWorkers; i++)
            {
                if (salaries[i, j] > maxSalary)
                {
                    maxSalary = salaries[i, j];
                    topWorker = workerNames[i];
                }
            }

            Console.WriteLine($"В месяце {j + 1} наибольшую зарплату получил {topWorker} ({maxSalary:C}).");
        }
        Console.ReadKey();  
    }
}

