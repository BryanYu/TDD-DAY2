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
        private decimal _threeDifferenceBooksDiscount = 0.90M;
        private decimal _fourDifferenceBooksDiscount = 0.80M;
        private decimal _fiveDifferenceBooksDiscount = 0.75M;

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
            var count = distinctBooks.Count();
            if (count == 2)
            {
                return _twoDifferenceBooksDiscount;
            }
            else if (count == 3)
            {
                return _threeDifferenceBooksDiscount;
            }
            else if (count == 4)
            {
                return _fourDifferenceBooksDiscount;
            }
            else if (count == 5)
            {
                return _fiveDifferenceBooksDiscount;
            }
            return _defaultDiscount;
        }
    }
}