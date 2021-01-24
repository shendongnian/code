    [TestFixture]
        public class Data_Should_Filter
        {
            [Test]
            [TestCase(new Product(1), new Category(2), DateTime.UtcNow)]
            [TestCase(new Product(2), new Category(2), DateTime.UtcNow)]
            public void TestFilter(Product product, Category category, DateTime creationDate)
            {
    
            }
        }
