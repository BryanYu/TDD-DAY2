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
        private decimal _defaultDiscount = 1.0M;
        private decimal _twoDifferenceBooksDiscount = 0.95M;
        private decimal _threeDifferenceBooksDiscount = 0.90M;
        private decimal _fourDifferenceBooksDiscount = 0.80M;
        private decimal _fiveDifferenceBooksDiscount = 0.75M;

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
            var booksSum = books.Sum(item => item.Price);
            decimal expected = booksSum * _twoDifferenceBooksDiscount;
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
            var booksSum = books.Sum(item => item.Price);
            decimal expected = booksSum * _threeDifferenceBooksDiscount;

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
            var booksSum = books.Sum(item => item.Price);
            decimal expected = booksSum * _fourDifferenceBooksDiscount;

            ///Act
            decimal actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_When_Buy_5_Difference_is_25_percent_discount()
        {
            ///Arrange
            var target = new PotterBooks();
            var books = _dummyBooks.Take(5);
            var booksSum = books.Sum(item => item.Price);
            decimal expected = booksSum * _fiveDifferenceBooksDiscount;

            ///Act
            decimal actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_When_Buy_4_But_3_Are_Difference_The_One_Are_Original_Price()
        {
            ///Arrange
            var target = new PotterBooks();
            var books = _dummyBooks.Take(3).ToList();
            var booksSum = books.Sum(item => item.Price);
            var firstBook = _dummyBooks.First(item => item.Id == 3);
            books.Add(firstBook);

            decimal expected = (booksSum * _threeDifferenceBooksDiscount) + firstBook.Price;

            ///Act
            decimal actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_When_Buy_4_But_2_Pair_Same()
        {
            ///Arrange
            var target = new PotterBooks();
            var books = _dummyBooks.Take(3).ToList();
            var booksSum = books.Sum(item => item.Price);
            var otherBooks = _dummyBooks.Where(item => item.Id >= 2 && item.Id <= 3);
            var otherBooksSum = otherBooks.Sum(item => item.Price);
            decimal expected =
                (booksSum * _threeDifferenceBooksDiscount) +
                (otherBooksSum * _twoDifferenceBooksDiscount);
            books.AddRange(otherBooks);

            ///Actual
            var actual = target.Calculate(books);

            ///Assert
            Assert.AreEqual(expected, actual);
        }
    }
}