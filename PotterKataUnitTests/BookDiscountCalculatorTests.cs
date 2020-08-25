namespace PotterKataUnitTests
{
    using System.Collections.Generic;

    using PotterKata.Models;
    using PotterKata.Processors;

    using Xunit;

    public class BookDiscountCalculatorTests
    {
        private List<BookOrder> _books = new List<BookOrder>();
        private BookPriceCalculator _sut = new BookPriceCalculator();
        
        [Fact]
        public void OneBookCostsFullAmount()
        {
            _books.Add(new BookOrder { Title = "Book1" });

            Assert.Equal(8, GetSutResult());
        }

        [Fact]
        public void BuyTwoBooksTheSameCostsFullAmount()
        {
            _books = new List<BookOrder>
                {
                    new BookOrder { Title = "Book1" }, 
                    new BookOrder { Title = "Book1" }
                };

            Assert.Equal(16, GetSutResult());
        }

        [Fact]
        public void BuyTwoDifferenceBooksGet5PercentDiscount()
        {
            _books = new List<BookOrder>
                {
                    new BookOrder { Title = "Book1" },
                    new BookOrder { Title = "Book2" }
                };

            Assert.Equal((decimal)15.2, GetSutResult());
        }

        [Fact]
        public void BuyThreeDifferentBooksGet10PercentDiscount()
        {
            _books = new List<BookOrder>
                {
                    new BookOrder { Title = "Book1" },
                    new BookOrder { Title = "Book2" },
                    new BookOrder { Title = "Book3" }
                };

            Assert.Equal((decimal)21.6, GetSutResult());
        }

        [Fact]
        public void BuyFourDifferentBooksGet20PercentDiscount()
        {
            _books = new List<BookOrder>
                {
                    new BookOrder { Title = "Book1" },
                    new BookOrder { Title = "Book2" },
                    new BookOrder { Title = "Book3" },
                    new BookOrder { Title = "Book4" }
                };

            Assert.Equal((decimal)25.6, GetSutResult());
        }

        [Fact]
        public void BuyAll5BooksGet25PercentDiscount()
        {
            _books = new List<BookOrder>
                {
                    new BookOrder { Title = "Book1" },
                    new BookOrder { Title = "Book2" },
                    new BookOrder { Title = "Book3" },
                    new BookOrder { Title = "Book4" },
                    new BookOrder { Title = "Book5" }
                };

            Assert.Equal(30, GetSutResult());
        }

        [Fact]
        public void WhenFourBooksArePurchasedButOnlyThreeUniqueFourthIsChargedAtFullPrice()
        {
            _books = new List<BookOrder>
                {
                    new BookOrder { Title = "Book1" },
                    new BookOrder { Title = "Book2" },
                    new BookOrder { Title = "Book3" },
                    new BookOrder { Title = "Book3" }
                };
            
            Assert.Equal((decimal)29.6, GetSutResult());
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, 8)]
        [InlineData(1, 1, 0, 0, 0, 15.20)]
        [InlineData(1, 1, 1, 0, 0, 21.60)]
        [InlineData(1, 0, 1, 0, 1, 21.60)]
        [InlineData(1, 1, 2, 0, 0, 29.60)]
        [InlineData(2, 2, 1, 0, 0, 36.80)]
        [InlineData(2, 2, 2, 2, 3, 68.00)]
        [InlineData(2, 2, 2, 1, 1, 51.60)]
        public void GetExpectedTotalFromBookPriceCalculator(
            int numberOfBook1,
            int numberOfBook2,
            int numberOfBook3,
            int numberOfBook4,
            int numberOfBook5,
            decimal expectedTotal)
        {
            PopulateBooksList("Book1", numberOfBook1);
            PopulateBooksList("Book2", numberOfBook2);
            PopulateBooksList("Book3", numberOfBook3);
            PopulateBooksList("Book4", numberOfBook4);
            PopulateBooksList("Book5", numberOfBook5);

            Assert.Equal(expectedTotal, GetSutResult());
        }

        private void PopulateBooksList(string title, int numberToPopulateWith)
        {
            for (var counter = 1; counter <= numberToPopulateWith; counter++)
            {
                _books.Add(new BookOrder { Title = title });
            }
        }

        private decimal GetSutResult()
        {
            return _sut.CalculateDiscountedPrice(_books);
        }

    }
}
