using System;
using System.Linq;
using Application;
using NUnit.Framework;
using Rhino.Mocks;


namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Server();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void CanServeSteak()
        {
            var order = "1";
            string expected = "steak";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);

        }
    }
}