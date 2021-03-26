using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Employee
{
    class Employee
    {
		internal string name;
		internal long salary;

		public void IncreaseSalary(long sum)
		{
			salary += sum;
		}

		//ToString() later
		public string DisplayInfo()
		{
			return "Name: " + name + ", Salary: " + salary;
		}
	}
}
