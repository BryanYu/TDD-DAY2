﻿using System;
using System.Collections.Generic;
using PotterShoppingCart.Model;

namespace PotterShoppingCart
{
    public class PotterBooks
    {
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
            throw new NotImplementedException();
        }
    }
}