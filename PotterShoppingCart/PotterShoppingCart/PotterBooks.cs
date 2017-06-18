using System;
using System.Collections.Generic;
using System.Linq;
using PotterShoppingCart.Model;

namespace PotterShoppingCart
{
    public class PotterBooks
    {
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
            var result = 0.0M;
            if (books.Count() == 2)
            {
                decimal totalPrice = books
                .Select(item => new { Id = item.Id, Price = item.Price })
                .Distinct()
                .Sum(item2 => item2.Price);
                result = totalPrice * _twoDifferenceBooksDiscount;
            }
            return result;
        }
    }
}