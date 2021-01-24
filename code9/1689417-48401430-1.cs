    [TestFixture]
    public class ExampleTest
    {
        Guid product1Guid;
        Guid product2Guid;
        List<Product> Products;
    
        [SetUp]
        public void PerTestPrepare()
        {
            product1Guid = Guid.NewGuid();
            product2Guid = Guid.NewGuid();
            Products = new List<Product>();
            var product1 = new Product(product1Guid), "Product 1");
            var product2 = new Product(product1Guid), "Product 2");
            Products.Add(product1);
            Products.Add(product2);
        }
    
        [Test]
        public void SimpleCheck_Containts_True()
        {
            Assert.IsTrue(Products.Any(p => p.Id == product1Guid));
        }
    }
