using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace book.Tests
{
    //NE SZERKESZD!!!!!!!!
    [TestClass()]
    public class BookTests
    {
        protected const string author = "J.K. Rowling";
        protected const string title = "Harry Potter";
        protected const int yearOfPublication = 2008;
        protected const int price = 3500;
        protected const int pages = 111;
        static Book book;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            book = new Book(author, title, price, pages);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!
        [TestMethod("A SetPrice-nak az 1000 feletti értéket érintetlenül kell hagynia!")]
        public void SetPrice_Above999_ShouldNotBeChanged()
        {
            book.SetPrice(price);
            Assert.AreEqual(price, book.GetPrice());
        }

        [TestMethod("Az IncreasePrice-nak pozitív értékre módosítania kell az árat!")]
        public void IncreasePrice_ByAPositiveValue_ShouldChangePrice()
        {
            book.SetPrice(price);
            int expectedIncreasedPrice = 4025;
            book.IncreasePrice(15);

            Assert.AreEqual(expectedIncreasedPrice, book.GetPrice());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataTestMethod]
        [DataRow(0)]
        [DataRow(-10)]
        [TestMethod("Az IncreasePrice-nak nem pozitív értékre nem szabad módosítania az árat!")]
        public void IncreasePrice_By0OrNegativeValue_ShouldNotChangePrice(int priceInc)
        {
            book.SetPrice(price);
            int expectedIncreasedPrice = book.GetPrice();
            book.IncreasePrice(priceInc);

            Assert.AreEqual(expectedIncreasedPrice, book.GetPrice());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataTestMethod]
        [DataRow(1004, 1104)]
        [DataRow(1005, 1105)]
        [DataRow(1006, 1107)]
        [TestMethod("Az IncreasePrice-nak tört eredmény esetén kerekítenie kell a matematikai szabályoknak megfelelõen!")]
        public void IncreasePrice_FractionalResult_ShouldBeRoundedAccordingToArithmeticRules(int originalPrice, int expectedPrice)
        {
            book.SetPrice(originalPrice);
            book.IncreasePrice(10);

            Assert.AreEqual(expectedPrice, book.GetPrice());
        }

        [DataRow(-1001)]
        [DataRow(-1000)]
        [DataRow(-999)]
        [DataRow(0)]
        [DataRow(999)]
        [TestMethod("Az SetPrice-nak az 1000 alatti értékeket 1000-re kell állítania")]
        public void SetPrice_Below1000_ShouldBeCorrectedTo1000(int price)
        {
            book.SetPrice(price);
            Assert.AreEqual(1000, book.GetPrice());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString kimenetének tartalmaznia kell a címet")]
        public void ToString_ResultShouldContainTitle()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(title));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString kimenetének tartalmaznia kell a szerzőt")]
        public void ToString_ResultShouldContainAuthor()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(author));
        }

        [TestMethod("A ToString kimenetének tartalmaznia kell a publikáció évét")]
        public void ToString_ResultShouldContainYearOfPublication()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(DateTime.Now.Year.ToString()));
        }

        [TestMethod("A ToString kimenetének tartalmaznia kell az arat")]
        public void ToString_ResultShouldContainPrice()
        {
            book.SetPrice(price);
            string result = book.ToString();

            Assert.IsTrue(result.Contains(price.ToString()));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString kimenetének tartalmaznia kell az oldalszámot")]
        public void ToString_ResultShouldContainPages()
        {
            book.SetPrice(pages);
            string result = book.ToString();

            Assert.IsTrue(result.Contains(pages.ToString()));
        }

        [TestMethod("A SetPages/Pages negatív bemenetre nem szabad,hogy változtassa a pages értékét!")]
        public void SetPages_ForNegativeValues_ShouldNotChangePages()
        {
            Book book = new Book(author, title, price, pages);

            book.SetPages(-1);
            Assert.AreEqual(pages, book.GetPages());

            book.Pages = -1;
            Assert.AreEqual(pages, book.Pages);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!
        [TestMethod("A 4 paraméteres konstruktornak a publikáció évét a jelen évre kell állítania!")]
        public void _4ParamConstructor_ShouldSetyearOfPublicationToCurrentYear()
        {
            Assert.AreEqual(DateTime.Now.Year, book.GetYearOfPublication());
        }

        [DataRow(1000, 1000)]
        [DataRow(0, 0)]
        [DataRow(-1000, 0)]
        [TestMethod("A 4 paraméteres konstruktornak az árat a megadott pozitív értékre kell állítania, vagy 0-ra, ha az nem pozitív!")]
        public void _4ParamConstructor_ShouldSetPriceToGivenPositiveValueOr0Otherwise(int setPrice, int expectedPrice)
        {
            Book book = new Book(author, title, setPrice, pages);
            Assert.AreEqual(expectedPrice, book.GetPrice());
        }

        [DataRow(1000, 1000)]
        [DataRow(0, 0)]
        [DataRow(-1000, 0)]
        [TestMethod("A 4 paraméteres konstruktornak az oldalszámot a megadott pozitív értékre kell állítania, vagy 0-ra, ha az nem pozitív!")]
        public void _4ParamConstructor_ShouldSetPagesToGivenPositiveValueOr0Otherwise(int setPages, int expectedPages)
        {
            Book book = new Book(author, title, price, setPages);
            Assert.AreEqual(expectedPages, book.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A 2 paraméteres konstruktornak az árat 2500-ra kell állítania!")]
        public void TwoParamConstructor_ShouldSetPriceTo2500()
        {
            book = new Book(author, title);
            Assert.AreEqual(2500, book.GetPrice());
        }

        [TestMethod("A 2 paraméteres konstruktornak 100-ra kell állítania az oldalszámot!")]
        public void TwoParamConstructor_ShouldSetPagesTo100()
        {
            book = new Book(author, title);
            Assert.AreEqual(100, book.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A GetLonger az elsõ könyvet adja vissza azonos oldalszám esetén!")]
        public void GetLonger_ForEqualPages_ShouldReturnFirstBook()
        {
            Book bookA = new Book(author, title, price, 1234);
            Book bookB = new Book(author, title, price, 1234);

            Book longer = Book.GetLonger(bookA, bookB);

            Assert.AreEqual(longer, bookA);
        }

        [DataRow(1, 2, 1)]
        [DataRow(2, 1, 0)]
        [TestMethod("A GetLonger a nagyobb oldalszámmal rendelkezõ könyvet adja vissza a 2 paraméter közül!")]
        public void GetLonger_ForDifferingPages_ShouldReturnTheLongerBook(int bookAPages, int bookBPages, int longerIndex)
        {
            Book[] books = {
                            new Book(author, title, price, bookAPages),
                            new Book(author, title, price, bookBPages)
                            };

            Book longer = Book.GetLonger(books[0], books[1]);

            Assert.AreEqual(longer, books[longerIndex]);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(33, false)]
        [DataRow(444, true)]
        [TestMethod("A HasEvenPages igazat ad vissza, ha páros a pages, hamisat ellenkezõ esetben!")]
        public void HasEvenPages_ShouldReturnTrueIfPagesIsEvenFalseOtherwise(int pages, bool isEven)
        {
            Book book = new Book(author, title, price, pages);

            Assert.AreEqual(isEven, book.HasEvenPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(1, 2, 3, 3)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(2, 3, 1, 3)]
        [DataRow(2, 1, 3, 3)]
        [TestMethod("A GetLongestBook visszaadja a leghosszabb könyvet!")]
        public void GetLongestBook_ShouldReturnTheBookWithTheMostPages(int pagesA, int pagesB, int pagesC, int longestPages)
        {
            Book[] books = {new Book(author, title, price, pagesA),
                            new Book(author, title, price, pagesB),
                            new Book(author, title, price, pagesC)
                            };

            Book longest = Book.GetLongestBook(books);

            Assert.AreEqual(longestPages, longest.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataRow(2, 1, 3, 3)]
        [DataRow(1, 2, 4, 5, 4)]
        [DataRow(4, 2, 1, 5, 4)]
        [DataRow(5, 4, 2, 1, 4)]
        [DataRow(2, 1, 5, 4, 4)]
        [TestMethod("A GetLongestEvenPagesBook visszaadja a leghosszabb páros oldalszámú könyvet!")]
        public void GetLongestEvenPagesBook_ShouldReturnTheBookWithTheMostEvenPages(int pagesA, int pagesB, int pagesC, int pagesD, int longestPages)
        {
            Book[] books = {new Book(author, title, price, pagesA),
                            new Book(author, title, price, pagesB),
                            new Book(author, title, price, pagesC),
                            new Book(author, title, price, pagesD)
                            };

            Book longest = Book.GetLongestEvenPagesBook(books);

            Assert.AreEqual(longestPages, longest.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(1, 3, 5, 7)]
        [TestMethod("A GetLongestEvenPagesBook visszaadja a leghosszabb páros oldalszámú könyvet!")]
        public void GetLongestEvenPagesBook_ForArraysWithNoEvenPageBooks_ShouldReturnNull(int pagesA, int pagesB, int pagesC, int pagesD)
        {
            Book[] books = {new Book(author, title, price, pagesA),
                            new Book(author, title, price, pagesB),
                            new Book(author, title, price, pagesC),
                            new Book(author, title, price, pagesD)
                            };

            Book longest = Book.GetLongestEvenPagesBook(books);

            Assert.IsNull(longest);
        }
    }
}