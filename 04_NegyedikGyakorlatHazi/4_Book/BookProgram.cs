using System;

namespace _4_Book
{
    class BookProgram
    {
        static void Main(string[] args)
        {
			Book book = new Book();
			//book.SetAuthor("Robert C. Martin");
			//book.SetTitle("Clean Code: A Handbook of Agile Software Craftsmanship");
			//book.SetYearOfPublication(2008);
			//book.SetPrice(8500);

			book.Author = "Robert C. Martin";
			book.Title = "Clean Code: A Handbook of Agile Software Craftsmanship";
			book.YearOfPublication = 2008;
			book.Price = 8500;

			Console.WriteLine(book.DisplayInformation());
			book.IncreasePrice(10);
            Console.WriteLine(book.DisplayInformation());
        }
    }
}
