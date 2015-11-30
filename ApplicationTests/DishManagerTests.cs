using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using NUnit.Framework;
using Rhino.Mocks;


namespace ApplicationTests
{
    [TestFixture]
    public class DishManagerTests
    {
        private DishManager _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishManager();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void EmptyListReturnsEmptyList()
        {
            var order = new List<int>();
            var actual = _sut.GetDishes(order);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void ListWith1ReturnsOneSteak()
        {
            var order = new List<int> {1};
            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("steak", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }

    }
}
