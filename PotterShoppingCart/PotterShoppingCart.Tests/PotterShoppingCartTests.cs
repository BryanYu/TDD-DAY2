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
            new Book { Name = "哈利波特第一集",Price = 100 },
            new Book { Name = "哈利波特第二集",Price = 100 },
            new Book { Name = "哈利波特第三集",Price = 100 },
            new Book { Name = "哈利波特第四集",Price = 100 },
            new Book { Name = "哈利波特第五集",Price = 100 }
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
    }
}