using System;

namespace _1_Employee
{
    class EmployeeTest
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            employee.name = "John Smith";
            employee.salary = 150000;

            Console.WriteLine(employee.DisplayInfo());
            employee.IncreaseSalary(1000);
            Console.WriteLine(employee.DisplayInfo());
        }
    }
}
