using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Book
{
    class Book
    {

        private string author;
        private string title;
        private int yearOfPublication;
        private int price;

        public Book(string author, string title, int yearOfPublication, int price)
        {
            this.author = author;
            this.title = title;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }
        static DateTime currentDate = DateTime.Now;
        public Book(string author, string title) : this(author, title, currentDate.Year, 2500) { }

        public override string ToString()
        {
            return author + ": " + title + "  Megjelenés éve: " + yearOfPublication + "  Ár: " + price;
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
