using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CykelLib;

namespace CykelTests
{
    [TestClass]
    public class CykelTest
    {
        private static Cykel cykel = new Cykel(1, "blå", 999.99, 16);

        [TestMethod]
        public void ConstructorTest()
        {
            Cykel cykel = new Cykel(2, "grøn", 1999.99, 4);

            Assert.AreEqual(2, cykel.Id);
            Assert.AreEqual("grøn", cykel.Color);
            Assert.AreEqual(1999.99, cykel.Price);
            Assert.AreEqual(4, cykel.Gear);
        }

        /// <summary>
        /// Tests if exceptions are thrown according to the setter
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestColorExceptionOnSet()
        {
            cykel.Color = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPriceExceptionOnSet()
        {
            cykel.Price = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGearExceptionOnSet()
        {
            cykel.Gear = 1;
        }
    }
}
