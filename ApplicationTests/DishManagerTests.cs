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

        [Test]
        public void EmptyListReturnsEmptyList()
        {
            var order = new Order();
            var actual = _sut.GetDishes(order);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void ListWith1ReturnsOneSteak()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    1
                },
                TimeOfDay = TimeOfDay.evening
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("steak", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }

        [Test]
        public void ListWith2ReturnsTwoPotatoes()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    2,
                    2
                },
                TimeOfDay = TimeOfDay.evening
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("potato", actual.First().DishName);
            Assert.AreEqual(2, actual.First().Count);
        }

        [Test]
        public void ListWith1ReturnsOneToast()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    2
                },
                TimeOfDay = TimeOfDay.morning
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("toast", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }

        [Test]
        public void ListWith2ReturnsTwoCoffees()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    3,
                    3
                },
                TimeOfDay = TimeOfDay.morning
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("coffee", actual.First().DishName);
            Assert.AreEqual(2, actual.First().Count);
        }

        [Test]
        public void ListWithTwoSteaksThrowsError()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    1,
                    1
                },
                TimeOfDay = TimeOfDay.evening
            };

            var actual = _sut.GetDishes(order);
            // throws exception
            //Assert.Throws(x => _sut.GetDishes(order));
        }
    }
}
