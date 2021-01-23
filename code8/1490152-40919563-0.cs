    [TestMethod]
    public void ProcessOrder_WhenSomeTestedCondition_ThenCertainExpectedResult()
    {
        // Arrange
        OrderConfirmation expectedResult = new OrderConfirmation(); // Set expected result here
        Order fakeRequest = new Order();
        List<Product> fakeProducts = new List<Product>();
        int fakeCreateOrderResult = 123;
        int fakeCreateOrderConfirmationResult = 456;
        // This is the mocked dependency
        Mock<IDataProvider> dataProviderMock = new Mock<IDataProvider>();
        // Here the method is setup so it returns some fake products
        dataProviderMock.Setup(dp => dp.GetAllProducts())
            .Returns(fakeProducts);
        // Here the method is setup so it returns some fake result
        dataProviderMock.Setup(dp => dp.CreateOrder(It.IsAny<int>(), It.IsAny<List<Product>>()))
            .Returns(fakeCreateOrderResult);
        // Here the method is setup so it returns some fake result
        dataProviderMock.Setup(dp => dp.CreateOrderConfirmation(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(fakeCreateOrderConfirmationResult);
        // Here the method UpdateListOfAvailableProducts returns void so
        // an example using callback is shouwing how the provided list of new products
        // could update the existing ones
        dataProviderMock.Setup(dp => dp.UpdateListOfAvailableProducts(
            new List<Product> { new Product {Price = 100, ProductId = 1, ProductName = "Product_X"}}))
            .Callback<List<Product>>(np =>
            {
                fakeProducts.AddRange(np);
            });
        // This is class under test which receives the mocked data provider object
        MyService service = new MyService(dataProviderMock.Object);
        // Act
        // Here the tested method is executed
        OrderConfirmation actualResult = service.ProcessOrder(fakeRequest);
        // Assert
        // Compare expected and actual results
        Assert.AreEqual(expectedResult.OrderId, actualResult.OrderId);
    }	
