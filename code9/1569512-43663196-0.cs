    [TestClass]
    public class PossibleAmazonProductMatchesTests
    {
        [TestMethod]
        public void Test1()
        {
            // Arrange
            var moqClient = new MarketplaceWebServiceProductsMock();
            // Act
            PossibleAmazonProductMatches possibleAmazonProductMatches = new PossibleAmazonProductMatches("spanners", moqClient);
            // Assert
            Assert.IsTrue(possibleAmazonProductMatches.PossibleProductList.Count == 10);
        }
    }
