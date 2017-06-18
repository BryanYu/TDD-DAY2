using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTests
    {
        private List<Book> _dummyBooks = new List<Book>
        {
            new Book {Id = 1 ,Name = "哈利波特第一集",Price = 100 },
            new Book {Id = 2 ,Name = "哈利波特第二集",Price = 100 },
            new Book {Id = 3 ,Name = "哈利波特第三集",Price = 100 },
            new Book {Id = 4 ,Name = "哈利波特第四集",Price = 100 },
            new Book {Id = 5 ,Name = "哈利波特第五集",Price = 100 }
        };

        [TestMethod]
        public void Test_Every_PotterBooks_Price_is_100()
        {
            ///Arrange
            var target = new PotterBooks();
            var expected = _dummyBooks;
            ///Act
            List<Book> actual = target.Get();

            ///Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Test_When_Buy_2_Difference_is_5_percent_discount()
        {
            ///Arrange
            var target = new PotterBooks();
            var books = _dummyBooks.Take(2);
            decimal expected = (100 + 100) * 0.95M;
            ///Act
            decimal actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_When_Buy_3_Difference_is_10_percent_discount()
        {
            ///Arrange
            var target = new PotterBooks();
            var books = _dummyBooks.Take(3);
            decimal expected = (100 + 100 + 100) * 0.90M;

            ///Act
            decimal actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_When_Buy_4_Difference_is_20_percent_discount()
        {
            ///Arrange
            var target = new PotterBooks();
            var books = _dummyBooks.Take(4);
            decimal expected = (100 + 100 + 100 + 100) * 0.80M;

            ///Act
            decimal actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }
    }
}