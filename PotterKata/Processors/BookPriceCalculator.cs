namespace PotterKata.Processors
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using PotterKata.Models;

    public class BookPriceCalculator
    {
        public decimal CalculateDiscountedPrice(List<Book> books)
        {
            var uniqueBooks = books.GroupBy(x => x.Title).Select(x => x.First());

            var uniqueBookPrice = uniqueBooks.Sum(x => x.Price);

            var totalNonDiscountedPrice = books.Sum(x => x.Price);

            decimal discount;

            switch (uniqueBooks.Count())
            {
                case 2:
                    discount = uniqueBookPrice * (decimal).05;
                    break;

                case 3:
                    discount = uniqueBookPrice * (decimal).1;
                    break;

                case 4:
                    discount = uniqueBookPrice * (decimal).2;
                    break;

                case 5:
                    discount = uniqueBookPrice * (decimal).25;
                    break;

                default:
                    return books.Sum(x => x.Price);
            }

            return totalNonDiscountedPrice - discount;
        }
    }
}
