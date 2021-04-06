using System;

namespace book
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
			    - A Program osztály Main függvényében olvasson be n darab könyvet egy tömbbe! 
                n értékét ellenőrzött módon olvassa be 1 és 10 között (ReadInteger())! 
                
                A könyvek létrehozásához az 1. konstruktort (4 parameteres) használja!
			*/

            Console.WriteLine("Number of books: ");
            int numberOfBooks = ReadInteger();

            //MEGOLDASOK HELYE
            //tomb letrehozasa
            Book[] bookArray = new Book[numberOfBooks]; 
            for (int i = 0; i < bookArray.Length; i++)
            {
                Console.Write("A könyv szerzője: ");
                string author = Console.ReadLine();
                Console.Write("A könyv címe: ");
                string title = Console.ReadLine();
                Console.Write("A könyv ára: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("A könyv oldalszáma: ");
                int pages = int.Parse(Console.ReadLine());
                //konyv adatainak bekerese
                //konyv letrehozasa
                bookArray[i] = new Book(author, title, price, pages);
            }

            //MEGOLDASOK HELYE
            //ListBookArray() hasznalata
            Book.ListBookArray(bookArray);
            //Leghosszabb könyv
            Console.WriteLine("Leghosszabb könyv: "+ Book.GetLongestBook(bookArray).ToString());
            //Leghosszabb páros oldalszámú könyv
            Console.WriteLine("Leghosszabb páros könyv: " + Book.GetLongestEvenPagesBook(bookArray).ToString());
            //AuthorStatistics() hasznalata
            Book.AuthorStatistics(bookArray);
        }

        private static int ReadInteger()
        {
            //IMPLEMENTALNI
            int number;
            do
            {
                number = int.Parse(Console.ReadLine());
            } while (number < 1 || number > 10);
            
            return number;
        }
    }
}
