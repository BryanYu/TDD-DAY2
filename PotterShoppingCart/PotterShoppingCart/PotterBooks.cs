using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Schema;
using PotterShoppingCart.Model;

namespace PotterShoppingCart
{
    public class PotterBooks
    {
        private Dictionary<int, decimal> _discount;

        public PotterBooks()
        {
            this._discount = new Dictionary<int, decimal>
                             {
                                 { 0, 0.0M },
                                 { 1, 1.0M },
                                 { 2, 0.95M },
                                 { 3, 0.90M },
                                 { 4, 0.80M },
                                 { 5, 0.75M }
                             };
        }

        public decimal Calculate(IEnumerable<Book> books)
        {
            var duplicateBooks = books.GroupBy(item => item.Id).Where(item2 => item2.Count() > 1)
                .Select(item3 => item3.First());
            var distinctBooks = books.Select(item => new { Id = item.Id, Price = item.Price })
                                 .Distinct();

            var dulicateDiscount = this._discount[duplicateBooks.Count()];
            var distinctDiscount = this._discount[distinctBooks.Count()];

            var duplicateTotalPrice = dulicateDiscount * duplicateBooks.Sum(item => item.Price);
            var distinctTotalPrice = distinctDiscount * distinctBooks.Sum(item => item.Price);

            return duplicateTotalPrice + distinctTotalPrice;
        }
    }
}