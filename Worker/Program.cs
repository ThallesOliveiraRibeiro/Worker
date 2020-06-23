using System;
using System.Globalization;
using WorkerYield.Entitites.Enums;
using WorkerYield.Entitites;


namespace WorkerYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter worker date: ");
            Console.Write("Name: ");
            string nameWorker = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double salaryWorker = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depName);
            Worker worker = new Worker(nameWorker, level, salaryWorker, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #{0} contract data:", i); // ou $"Enter #{i} contract data"
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime dateworker = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int duration = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(dateworker, valHour, duration);

                worker.AddContract(contract);




            }
            
            Console.Write("Enter month and year to calculate income (MM/yyyy): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name : " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for "+monthAndYear + ": " + worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture));

            








        }
    }
}
