using System;
using System.Collections.Generic;
using System.Text;

namespace book
{
    /*
    A szerző, cím és ár adattagok változatlanok. 
    A megjelenés éve (yearOfPublication) legyen readonly konstans, az objektum létrehozás éve (dátumkezeléssel!).
    Egészítse ki az osztályt új adattaggal:
    - oldalszám (pages)

    Módosítsa a 2 konstruktort.
    - Az első konstruktor 4 paraméteres (szerző, cím, ár, oldalszám).
    Az ár és az oldalszám nem lehet negatív (default értékük 0).
    - A második konstruktor 2 paraméteres (szerző, cím). Az árat 2500 Ft-ra, az oldalszámot 100-ra állítja.

    Törölje a DisplayInformation() metódust.
    Módosítsa a ToString() metódust, amely String-ben összefűzve adja vissza a könyv adatait.
    (formatum: szerzo: cim, kiadaseve. Price: ar Ft, pp oldalszam)
    Hozza létre az új adattagokhoz a getter, setter tulajdonságokat és metódusokat. 
    Ha oldalszámnak negatív számot adunk, ne változzon az értéke.
    Írjon osztályszintű metódust, amely két paraméterként kapott könyv közül a hosszabbat adja vissza (GetLonger()). 
    Azonos oldalszám esetén az első könyvet. 
    Írjon példányszintű metódust, amely igazat ad vissza, ha a könyv oldalszáma páros (HasEvenPages()).

    Oldja meg az alábbi feladatokat:
    - A Program osztály Main függvényében olvasson be n darab könyvet egy tömbbe! 
      n értékét ellenőrzött módon olvassa be 1 és 10 között (ReadInteger())! 
      A könyvek létrehozásához az 1. konstruktort használja!
    - A Book osztályba írjon public static módosítójú tömbkiíró metódust (void ListBookArray(Book[])) 
    és írja ki vele a beolvasott könyveket a Program.Main függvényen belül!
    - A Book osztályba írjon public static módosítójú Book GetLongestBook(Book[]) metódust, 
    ami megkeresi és visszaadja a leghosszabb könyvet! 
    Írja ki ennek a könyvnek az adatait a Program osztály Main függvényén belül!
    - A Book osztályba írjon public static módosítójú Book GetLongestEvenPagesBook(Book[]) metódust, 
    ami megkeresi és visszaadja a leghosszabb páros oldalszámú könyet! 
    Ha nincs páros oldalszámú könyv a kapott tömbben, adjon vissza null-t! 
    Írja ki ennek a könyvnek az adatait a Homework osztály main függvényén belül!
        Algoritmus:
            Beállítjuk a maxBook változót null-ra.
            A tömb elemein végighaladva
                megvizsgáljuk, hogy az adott elem páros oldalszámú-e,
                    ha igen,
                        eltároljuk az elemet a maxBook változóban
                        kilépünk a ciklusból
            A tömb elemein végighaladva
                megvizsgáljuk, hogy az adott elem páros oldalszámú-e és nagyobb-e az oldalszáma a maxBook-ban tárolt könyvnél
                ha igen
                    A maxBook-ot beállítjuk a jelenlegi tömbelemre
            Visszatérünk a maxBook változóval
    - A Book osztályba írjon public static módosítójú (void AuthorStatistics(Book[])) metódust, 
    amely kiírja mely szerzőnek hány könyve jelent meg! 
    A Program.Main függvényen belül írassa ki a beolvasott könyvek statisztikáit!
    Algoritmus: Veszem a következő könyvet. 
    Ha a szerzője megegyezik egy korábban már vizsgált könyv szerzőjével, akkor továbblépek a következő könyvre. 
    Ha ez az adott szerző első előfordulása, akkor létrehozok egy számláló változót 1 értékkel és kiírom a szerző nevét. 
    Az aktuális indextől kezdve nézem a könyvek szerzőit, ha azonos szerzőt találok, növelem eggyel a számlálót.
    A végén kiírom a számláló értékét.
         */
    public class Book
    {
        private string author;
        private string title;
        private readonly int yearOfPublication = DateTime.Now.Year;
        private int price;
        private int pages;        

        public Book(string author, string title, int price, int pages)
        {
            this.author = author;
            this.title = title;
            if (price < 0)
            {
                price = 0;
            }
            if (pages < 0)
            {
                pages = 0;
            }
            this.price = price;
            this.pages = pages;
        }

        public Book(string author, string title)
        {
            this.author = author;
            this.title = title;
            this.price = 2500;
            this.pages = 100;
        }

        public override string ToString()
        {
            return author + ": " + title + ", " + yearOfPublication + ". Price: " + price + " Ft, pp " + pages;
        }

        public static Book GetLonger(Book a, Book b)
        {
            if (a.Pages < b.Pages)
            {
                return b;
            }
            else
            {
                return a;
            }
        }

        public bool HasEvenPages()
        {
            return Pages % 2 == 0;
        }

        public static void ListBookArray(Book[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine(Array[i].ToString());
            }
        }

        public static Book GetLongestBook(Book[] Array)
        {
            Book mx = Array[0];
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].Pages > mx.Pages)
                {
                    mx = Array[i];
                }
            }
            return mx;
        }

        public static Book GetLongestEvenPagesBook(Book[] Array)
        {
            Book mxpg = null;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].Pages % 2 == 0)
                {
                    mxpg = Array[i];
                    break;
                }
            }
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].Pages % 2 ==0 && Array[i].Pages > mxpg.Pages)
                {
                    mxpg = Array[i];
                }
            }
            return mxpg;
        }

        public static void AuthorStatistics(Book[] Array)
        {
            List<string> authors = new List<string>();
            for (int i = 0; i < Array.Length; i++)
            {
                authors.Add(Array[i].Author);
            }
            int[] bookNumbers = new int[authors.Count];
            for (int i = 0; i < bookNumbers.Length; i++)
            {
                bookNumbers[i] = 0;
            }
            for (int i = 0; i < authors.Count; i++)
            {
                for (int j = 0; j < Array.Length; j++)
                {
                    if (authors[i] == Array[j].Author)
                    {
                        bookNumbers[j++]++;
                    }
                }
            }
            for (int i = 0; i < bookNumbers.Length; i++)
            {
                Console.WriteLine(Array[i].Author +": "+ bookNumbers[i++]);
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                //Értékadás előtti ellenőrzés:
                //- az ár legyen 1000 forint 1000-nél kisebb értékekre, egyébként a megadott érték
                price = value;
            }
        }

        public int YearOfPublication
        {
            get { return yearOfPublication; }
            /*set
            {
                //Értékadás előtti ellenőrzés:
                //- a megjelenés éve, ha nem 1950 és 2021 között van, legyen 2021, egyébként a megadott érték
                yearOfPublication = value;
            }*/
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
        public int Pages
        {
            get { return pages; }
            set 
            {
                if (value > 0)
                {
                    pages = value;
                }
            }
        }
        public int GetPages()
        { return Pages; }

        public int GetPrice()
        { return Price; }

        public void SetPrice(int value)
        {
            if (value < 1000)
            {
                value = 1000;
            }
            Price = value;
        }

        public void SetPages(int value)
        { Price = value; }

        public int GetYearOfPublication()
        { return YearOfPublication; }

        /*public void SetYearOfPublication(int value)
        { YearOfPublication = value; }*/

        public string GetTitle()
        { return Title; }

        public void SetTitle(string value)
        { Title = value; }

        public string GetAuthor()
        { return Author; }

        public void SetAuthor(string value)
        { Author = value; }

        public void IncreasePrice(int percentage)
        {
            if (percentage > 0)
                price += (int)Math.Round(price * percentage / 100.0);
        }

        /*public string DisplayInformation()
        {
            return author + ": " + title + ", " + yearOfPublication + ". Price: " + price + " Ft";
        }*/
    }
}
