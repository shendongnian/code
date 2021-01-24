    [TestFixture(typeof(string))]
    [TestFixture(typeof(DateTime))]
    public class GenericTests<T>
    {
        [Test]
        public void GenericTestMethod()
        {
            Assert.Pass($"The type is {typeof(T)}");
        }
    }
