    [TestFixture]
    public class MyFixture
    {
        [Test]
        public void MyTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<Product>();
    
            // Use product, and whatever else fixture creates, in the test
        }
    }
