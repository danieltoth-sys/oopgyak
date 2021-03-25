using System;

namespace _3_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
			int size = 10;
			Employee[] employeeArray = new Employee[size];

			for (int i = 0; i < employeeArray.Length; i++)
			{
				employeeArray[i] = new Employee();
				employeeArray[i].SetSalary((i + 1) * 100000 + i * 200);
				employeeArray[i].SetName("Worker_" + (i + 1));
			}

			ListArray(employeeArray);

			Console.WriteLine("Best paid employee : " + employeeArray[HasMaxSalary(employeeArray)].GetName());
			Console.WriteLine("Average salary : " + AverageSalary(employeeArray));

			Console.WriteLine("Give a salary range : ");
			long lowerBoundary = ReadLowerBoundary(100000);
			long upperBoundary = ReadUpperBoundary(lowerBoundary);
			Console.WriteLine("Number of salaries in range: " + CountSalaries(employeeArray, lowerBoundary, upperBoundary));

			Console.WriteLine("Sum of tax to be paid: " + SumTax(employeeArray));
		}

		public static int HasMaxSalary(Employee[] employeeArray)
		{
			int maxIndex = 0;

			for (int i = 1; i < employeeArray.Length; i++)
			{
				if (employeeArray[i].HasHigherSalary(employeeArray[maxIndex]))
				{
					maxIndex = i;
				}
			}

			return maxIndex;
		}

		public static long AverageSalary(Employee[] employeeArray)
		{
			double average = 0;

			foreach (Employee employee in employeeArray)
			{
				//average += employee.GetSalary();
				average += employee.Salary;
			}

			average /= employeeArray.Length;

			return (long)average;
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

		public static int CountSalaries(Employee[] employeeArray, long lowerBoundary, long upperBoundary)
		{
			int counter = 0;

			foreach (Employee employee in employeeArray)
			{
				if (employee.IsInSalaryRange(lowerBoundary, upperBoundary))
				{
					counter++;
				}
			}

			return counter;
		}

		public static long SumTax(Employee[] employeeArray)
		{
			long sum = 0;
			foreach (Employee employee in employeeArray)
			{
				sum += employee.GetTax();
			}

			return sum;
		}

		public static void ListArray(Employee[] employeeArray)
		{
			foreach (Employee employee in employeeArray)
			{
				Console.WriteLine(employee.DisplayInfo());
			}
		}

	}
}
