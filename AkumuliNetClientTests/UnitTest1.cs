using AkumuliNetClient;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var a = new Akumuli("localhost", 8000, 8001, 8002);
            Assert.AreEqual("localhost", a.Host);
            Assert.AreEqual(8000, a.PortREST);
            Assert.AreEqual(8001, a.PortUDP);
            Assert.AreEqual(8002, a.PortTCP);
        }
    }
}