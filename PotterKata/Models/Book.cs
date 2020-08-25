namespace PotterKata.Models
{
    using System;

    public class BookOrder
    {
        public BookOrder()
        {
            if (BookOrderId.Equals(Guid.Empty))
            {
                BookOrderId = Guid.NewGuid();
            }
        }

        public Guid BookOrderId { get; set; }

        public string Title { get; set; }

        public decimal Price => 8;
    }
}
