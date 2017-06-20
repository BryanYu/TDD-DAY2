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
        private List<Book> _dummyBooks = new List<Book>();

        [TestMethod]
        public void 測試_只買第一集價錢為100()
        {
            ///Arrange
            var target = new PotterBooks();
            _dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            decimal expected = 100;

            ///Act
            var actual = target.Calculate(this._dummyBooks);

            ///Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 測試_買第一二集價錢為190()
        {
            ///Arrange
            var target = new PotterBooks();
            this._dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });

            decimal expected = 190;
            ///Act
            decimal actual = target.Calculate(this._dummyBooks);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 測試_買第一二三集價錢為270()
        {
            ///Arrange
            var target = new PotterBooks();
            this._dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });

            decimal expected = 270;

            ///Act
            decimal actual = target.Calculate(this._dummyBooks);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 測試_買第一二三四集價錢為320()
        {
            ///Arrange
            var target = new PotterBooks();
            this._dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 4, Name = "哈利波特第四集", Price = 100 });

            decimal expected = 320;

            ///Act
            decimal actual = target.Calculate(this._dummyBooks);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 測試_買第一二三四五集價錢為375()
        {
            ///Arrange
            var target = new PotterBooks();
            this._dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 4, Name = "哈利波特第四集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 5, Name = "哈利波特第五集", Price = 100 });

            decimal expected = 375;

            ///Act
            decimal actual = target.Calculate(this._dummyBooks);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 測試_第一二集買一本_第三集買兩本_價錢為370()
        {
            ///Arrange
            var target = new PotterBooks();
            this._dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });

            decimal expected = 370;

            ///Act
            decimal actual = target.Calculate(this._dummyBooks);

            ///Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 測試_第一集買一本_第二三集買兩本_價錢為_460()
        {
            ///Arrange
            var target = new PotterBooks();
            this._dummyBooks.Add(new Book { Id = 1, Name = "哈利波特第一集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 2, Name = "哈利波特第二集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });
            this._dummyBooks.Add(new Book { Id = 3, Name = "哈利波特第三集", Price = 100 });

            var expected = 460;

            ///Actual
            var actual = target.Calculate(this._dummyBooks);

            ///Assert
            Assert.AreEqual(expected, actual);
        }
    }
}