    [TestFixture]
    public class ProductProviderTests
    {
        [Test]
        public void ShouldHaveProducts()
        {
            var services = ProductContext.GiventServices();
            var products = services.WhenListProducts(1);
            products.Count.Should().NotBe(0);
        }
        [Test]
        public void ShouldHaveDuplicateVariants()
        {
            var services = ProductContext.GiventServices();
            var products = services.WhenListProducts(1);
            var anyDuplicate = products.GroupBy(x => x.SelectToken("variant").ToString()).Any(g => g.Count() > 1);
            anyDuplicate.Should().Be(true);
        }
        [Test]
        public void ShouldNotHaveDuplicateGtins()
        {
            var services = ProductContext.GiventServices();
            var products = services.WhenListProducts(1);
            var anyDuplicate = products.GroupBy(x => x.SelectToken("gtin").ToString()).Any(g => g.Count() > 1);
            anyDuplicate.Should().Be(false);
        }
    }
