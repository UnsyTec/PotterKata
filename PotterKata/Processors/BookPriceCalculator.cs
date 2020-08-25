namespace PotterKata.Processors
{
    using System.Collections.Generic;
    using System.Linq;

    using PotterKata.Models;

    public class BookPriceCalculator
    {
        public decimal CalculateDiscountedPrice(List<BookOrder> bookOrders)
        {
            var uniqueBooks = bookOrders.GroupBy(x => x.Title).Select(x => x.First()).ToArray();

            var totalPrice = (decimal)0;

            while (bookOrders.Count > 0)
            {
                totalPrice += CalculatePriceForSelectedBooks(uniqueBooks);
                foreach (var bookOrder in uniqueBooks)
                {
                    bookOrders.Remove(bookOrder);
                }

                uniqueBooks = bookOrders.GroupBy(x => x.Title).Select(x => x.First()).ToArray();
            }

            return totalPrice;
        }

        private static decimal CalculatePriceForSelectedBooks(BookOrder[] bookOrders)
        {
            var totalNonDiscountedPrice = bookOrders.Sum(x => x.Price);

            decimal discount;

            switch (bookOrders.Count())
            {
                case 1:
                    return bookOrders.Sum(x => x.Price);
                case 2:
                    discount = totalNonDiscountedPrice * (decimal).05;
                    break;

                case 3:
                    discount = totalNonDiscountedPrice * (decimal).1;
                    break;

                case 4:
                    discount = totalNonDiscountedPrice * (decimal).2;
                    break;

                case 5:
                    discount = totalNonDiscountedPrice * (decimal).25;
                    break;

                default:
                    discount = totalNonDiscountedPrice * (decimal).25;
                    break;
            }

            return totalNonDiscountedPrice - discount;
        }
    }
}
