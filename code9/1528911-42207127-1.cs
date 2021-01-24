    public class ProductServiceTests
    {
        ProductService serviceToTest;
        IProductRepository productRepository;
        public ProductServiceTests()
        {
            this.productRepository = Mock<IProductRepository>();
            this.serviceToTest = new ProductService(productRepository);
        }
        public void GetProductByIdReturnsNullIfProductIdIsZero()
        {
            int productid = 0;
            var product = serviceToTest.GetProductById(productid);
            Assert.That(product, Is.Null);
        }
        public void GetProductByIdReturnsNullIfProductIdIsNegative()
        {
            int productid = -1;
            var product = serviceToTest.GetProductById(productid);
            Assert.That(product, Is.Null);
        }
        public void GetProductByIdReturnsProductIfProductIdIsPositive()
        {
            var productid = 1;
            var product = new Product { Id = productId };
            productRepository.Setup(repo => repo.GetProductById(productid)).Returns(product); //Making sure that GetProductById method of repository is called and return an object of product as this call is part of the code which I am testing right now.
            var product = serviceToTest.GetProductById(productid);
            Assert.That(product, Is.Not.Null);
            Assert.That(product.Id, Is.EqualTo<int>(productid));
        }
    }
