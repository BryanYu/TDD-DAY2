using System;
using System.Collections.Generic;
using System.Linq;
using PotterShoppingCart.Model;

namespace PotterShoppingCart
{
    public class PotterBooks
    {
        private decimal _defaultDiscount = 1.0M;
        private decimal _twoDifferenceBooksDiscount = 0.95M;

        public PotterBooks()
        {
        }

        public List<Book> Get()
        {
            var result = new List<Book>
            {
            new Book {Id = 1 ,Name = "哈利波特第一集",Price = 100 },
            new Book {Id = 2 ,Name = "哈利波特第二集",Price = 100 },
            new Book {Id = 3 ,Name = "哈利波特第三集",Price = 100 },
            new Book {Id = 4 ,Name = "哈利波特第四集",Price = 100 },
            new Book {Id = 5 ,Name = "哈利波特第五集",Price = 100 }
            };
            return result;
        }

        public decimal Calculate(IEnumerable<Book> books)
        {
            var result = GetPrice(books);
            return result;
        }

        private decimal GetPrice(IEnumerable<Book> books)
        {
            var discount = GetDiscount(books);
            var totalPrice = books.Sum(item => item.Price);
            return totalPrice * discount;
        }

        private decimal GetDiscount(IEnumerable<Book> books)
        {
            var distinctBooks = books.Select(item => item.Id).Distinct();
            if (distinctBooks.Count() >= 2)
            {
                return _twoDifferenceBooksDiscount;
            }
            return _defaultDiscount;
        }
    }
}