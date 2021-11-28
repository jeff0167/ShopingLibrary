using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopingLibrary;
using System;
using System.Xml.Linq;

namespace ShopingLibrary.Test
{
    [TestClass]
    public class ShopingItemTest
    {
        [TestMethod]
        [DataRow(1, "pasta", 5, "7 eleven")]
        [DataRow(2, "pants", 5754, "lidle")]
        public void ShopingItem_ShouldCreateObject(int id, string name, int quantity, string shopName) //int id, string name, int quantity, string shopName
        {
            ShopingItem Current = new ShopingItem(id, name, quantity, shopName);

            Assert.AreEqual(id, Current.Id);
            Assert.AreEqual(name, Current.Name);
            Assert.AreEqual(quantity, Current.Quantity);
            Assert.AreEqual(shopName, Current.ShopName);
        }

        [TestMethod]
        [DataRow(1, "pasta", 5, "7 eleven")]
        [DataRow(2, "pants", 5754, "lidle")]
        public void ShopingItem_ShouldReturnToString(int id, string name, int quantity, string shopName)
        {
            ShopingItem Current = new ShopingItem(id, name, quantity, shopName);

            Assert.AreEqual(Current.ToString(), $"id: {id}, name: {name}, quantity: {quantity}, shop name: {shopName}");
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("g")]
        [ExpectedException(typeof(ArgumentException))]
        public void ShopingItem_ShouldThrowExceptionOnInvalidNameLength(string name)
        {
            ShopingItem Current = new ShopingItem(1, name, 1, "shop");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShopingItem_ShouldThrowExceptionOnNameEqualNull()
        {
            ShopingItem Current = new ShopingItem(1, null, 1, "shop");
        }

        [TestMethod]
        public void ShopingItem_ShouldThrowExceptionMessageOnNameEqualNull()
        {
            try
            {
                ShopingItem Current = new ShopingItem(1, null, 1, "shop");

            }
            catch (Exception e)
            {

                Assert.AreEqual(e.Message, "Must be at least 2 char long and not null");
            }
        }
        
        [TestMethod]
        public void ShopingItem_ShouldThrowExceptionMessageOnInvalidQuantity()
        {
            try
            {
                ShopingItem Current = new ShopingItem(1, "zoro", 0, "shop");

            }
            catch (ArgumentOutOfRangeException e)
            {

                Assert.AreEqual(e.ParamName, "Must have a quantity over the value of 0");
            }
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShopingItem_ShouldThrowExceptionOnQuantityLessThanOne(int quantity)
        {
            ShopingItem Current = new ShopingItem(1, "pasta", quantity, "shop");
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(int.MaxValue)]
        public void ShopingItem_ShouldSetAllowedQuantityValues(int quantity)
        {
            ShopingItem Current = new ShopingItem(1, "pasta", quantity, "shop");

            Assert.AreEqual(Current.Quantity, quantity);
        }

        [TestMethod]
        public void ShopingItem_ShouldNotThrowExceptionOnShopNameEqualNull()
        {
            try
            {
                ShopingItem Current = new ShopingItem(1, "pasta", 1, null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
}
