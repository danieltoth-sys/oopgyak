using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Employee
{
    class Employee
    {
		private string name;
        private long salary;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public long Salary
        {
            get { return salary; }
            set { salary = value; }
        }


        public string GetName()
        { return name; }

        public void SetName(string value)
        { name = value; }

        public long GetSalary()
        { return salary; }

        public void SetSalary(long value)
        { salary = value; }

        public void IncreaseSalary(long sum)
		{
			salary += sum;
		}

		public string DisplayInfo()
		{
			return "Name: " + name + ", Salary: " + salary;
		}

		public bool IsInSalaryRange(long lowerBoundary, long upperBoundary)
		{

			if (salary <= upperBoundary && salary >= lowerBoundary)
				return true;
			else
				return false;
		}

		public long GetTax()
		{
			return (long)(salary * 0.16);
		}

		public bool HasHigherSalary(Employee employee)
		{
			if (this.salary > employee.salary)
				return true;
			else
				return false;
		}
	}
}
