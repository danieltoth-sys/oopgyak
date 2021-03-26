using System;

namespace _2_Employee
{
    class EmployeeTest
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            employee.Name = "John Doe";
            employee.SetSalary(150000);

            Console.WriteLine(employee.DisplayInfo());
            employee.IncreaseSalary(1000);
            Console.WriteLine(employee.DisplayInfo());

            //Console.WriteLine(employee.GetName() + "'s salary is " + employee.GetSalary());
            //Console.WriteLine(employee.Name + "'s salary is " + employee.Salary);
            Console.WriteLine($"{employee.Name}'s salary is {employee.Salary}");

            long lowerBoundary = ReadLowerBoundary(100000);
            long upperBoundary = ReadUpperBoundary(lowerBoundary);
            
            Console.Write("Salary is in [" + lowerBoundary + " - " + upperBoundary + "] : ");
            Console.WriteLine(employee.IsInSalaryRange(lowerBoundary, upperBoundary));

            Console.WriteLine("Tax to be paid: " + employee.GetTax());

            Employee otherEmployee = new Employee();
            otherEmployee.SetName("Jane Doe");
            otherEmployee.SetSalary(150000);

            if (employee.HasHigherSalary(otherEmployee))
                //Console.WriteLine(employee.GetName() + " has higher salary than " + otherEmployee.GetName());
                Console.WriteLine(employee.Name + " has higher salary than " + otherEmployee.Name);
            else
                //Console.WriteLine(otherEmployee.GetName() + " has higher salary than " + employee.GetName());
                Console.WriteLine(otherEmployee.Name + " has higher salary than " + employee.Name);
        }

        public static long ReadLowerBoundary(int minimalNumber)
        {
            long number;

            do
            {
                number = ReadInteger($"Enter lower boundary (min. {minimalNumber}): ");
            } while (number < minimalNumber);

            return number;
        }

        public static long ReadUpperBoundary(long lowerBoundary)
        {
            long number;
            
            do
            {
                number = ReadInteger("Enter upper boundary: ");
            } while (number <= lowerBoundary);

            return number;
        }

        private static long ReadInteger(string text)
        {
            //controlled integer reading
            long number;
            string readString;
            bool successRead;

            do
            {
                Console.WriteLine(text);

                readString = Console.ReadLine();
                successRead = Int64.TryParse(readString, out number);

                if (!successRead)
                {
                    Console.WriteLine("That's not a number");
                }
            } while (!successRead);

            return number;
        }
    }
}
