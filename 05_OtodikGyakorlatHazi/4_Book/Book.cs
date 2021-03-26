using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Book
{

    class futtathato
    {

        static void Main(string[] args)
        {
            int n = 3;
            Book[] book = new Book[n];

            for (int i = 0; i < book.Length; i++)
            {
                Console.WriteLine("Add meg az {0}. könyv adatait: ", i + 1);

                Console.Write("\tSzerző: ");
                string Author = Console.ReadLine();
                Console.Write("\tCím: ");
                string Title = Console.ReadLine();
                Console.Write("\tKiadás éve: ");
                int YearOfPublication = int.Parse(Console.ReadLine());
                Console.Write("\tÁr: ");
                int Price = int.Parse(Console.ReadLine());
                Console.Write("\tOldalszám: ");
                int Page = int.Parse(Console.ReadLine());
                Console.Write("\tKiadó: ");
                string Publisher = Console.ReadLine();

                book[i] = new Book(Author, Title, YearOfPublication, Price, Page, Publisher);
            }
            int maxindex = -1;
            int maxOldalszam = 0;
            for (int i = 0; i < book.Length; i++)
            {
                if (book[i].OldalszamParos())
                {
                    maxindex = i;
                    if (book[i].Page > maxOldalszam)
                    {
                        maxOldalszam = book[i].Page;
                        maxindex = i;
                    }

                }
            }
            book[maxindex].ToString();

            HashSet<string> publishers = new HashSet<string>();

            for (int i = 0; i < book.Length; i++)
            {
                publishers.Add(book[i].Publisher);
            }
            foreach (var item in publishers)
            {
                int darab = 0;
                for (int i = 0; i < book.Length; i++)
                {
                    if (book[i].Publisher == item)
                    {
                        darab++;
                    }
                }
                Console.WriteLine($"\t{item} szerzőnek {darab} könyve van.");
            }
        }


    }
    class Book
    {

        private string author;
        private string title;
        private int yearOfPublication;
        private int price;
        private int page;
        private string publisher;
        public Book(string author, string title, int yearOfPublication, int price, int page, string publisher)
        {
            this.author = author;
            this.title = title;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
            this.page = page;
            this.publisher = publisher;
        }
        public Book(string author, string title, int yearOfPublication, int price, int page)
        {
            this.author = author;
            this.title = title;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
            this.Page = page;
            this.Publisher = "Móra";
        }

        public Book(string author, string title, int price, int page)
        {
            this.author = author;
            this.title = title;
            this.yearOfPublication = currentDate.Year;
            this.price = price;
            this.Page = page;
            this.Publisher = "Móra";

        }
        static DateTime currentDate = DateTime.Now;
        public Book(string author, string title, int page) : this(author, title, currentDate.Year, 2500, page) { }

        public override string ToString()
        {
            return author + ": " + title + "  Megjelenés éve: " + yearOfPublication + "  Ár: " + price + "Oldalszám: " + Page + "Kiadó: " + Publisher;
        }

        public Book HosszabbKonyv(Book a, Book b)
        {
            if (a.Page > b.Page)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public bool OldalszamParos()
        {
            if (Page % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int YearOfPublication
        {
            get { return yearOfPublication; }
            set { yearOfPublication = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int Page { get => page; set => page = value; }
        public string Publisher { get => publisher; set => publisher = value; }

        public int GetPrice()
        { return price; }

        public void SetPrice(int value)
        { price = value; }

        public int GetYearOfPublication()
        { return yearOfPublication; }

        public void SetYearOfPublication(int value)
        { yearOfPublication = value; }

        public string GetTitle()
        { return title; }

        public void SetTitle(string value)
        { title = value; }

        public string GetAuthor()
        { return author; }

        public void SetAuthor(string value)
        { author = value; }

        public void IncreasePrice(int percentage)
        {
            price += (int)(price * percentage / 100.0);
        }

        public string DisplayInformation()
        {
            return author + ": " + title + ", " + yearOfPublication + ". Price: " + price + " Ft";
        }

    }
}
