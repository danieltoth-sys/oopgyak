using System;

namespace _5_Person
{
    class PersonProgram
    {
        static void Main(string[] args)
        {
			Person person = new Person();

			Console.Write("Name: ");
			person.Name = Console.ReadLine();

			Console.Write("Weight (kg): ");
			person.Weight = Convert.ToInt32(Console.ReadLine());

			Console.Write("Height (m): ");
			person.Height = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine(person.DisplayInformation());
		}
    }
}
