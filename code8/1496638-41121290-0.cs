    [TestFixture]
    public class TestClass
    {
        private const int BASE_VALUE = -1;
        private const int FIRST_MOCK_VALUE = 1;
        private const int SECOND_MOCK_VALUE = 2;
        public class Foo
        {
            public virtual int Bar()
            {
                return BASE_VALUE;
            }
        }
        [Test]
        public void Test()
        {
            var mock = new Mock<Foo>();
            mock.CallBase = true;
            var mockedObject = mock.Object;
            int actualValue = mockedObject.Bar();
            Assert.AreEqual(BASE_VALUE, actualValue);
            mock.Setup(m => m.Bar()).Returns(FIRST_MOCK_VALUE);
            actualValue = mockedObject.Bar();
            Assert.AreEqual(FIRST_MOCK_VALUE, actualValue);
            mock.Setup(m => m.Bar()).Returns(SECOND_MOCK_VALUE);
            actualValue = mockedObject.Bar();
            Assert.AreEqual(SECOND_MOCK_VALUE, actualValue);
        }
    }
