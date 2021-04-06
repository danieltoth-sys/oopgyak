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

            //for (int i = 0; i < bookArray.Length; i++)
            {
                //konyv adatainak bekerese
                //konyv letrehozasa
            }

            //MEGOLDASOK HELYE
            //ListBookArray() hasznalata

            //Leghosszabb könyv

            //Leghosszabb páros oldalszámú könyv

            //AuthorStatistics() hasznalata
        }

        private static int ReadInteger()
        {
            //IMPLEMENTALNI
            throw new NotImplementedException();
        }
    }
}
