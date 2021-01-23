    using NUnit.Framework;
    [TestFixture]
    public class HelloTest
    {
        [Test]
        public void Stating_something ()
        {
            Assert.AreEqual("Hello world.", Greeter.Hello());
        }
    }
