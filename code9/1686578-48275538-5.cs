    [TestMethod]
    public void OrderService_ShouldReceiveOrder()
    {
        // Arrange
        var mockOrderManager = new Mock<IOrderManager>();
        mockOrderManager.Setup(It.IsAny<List<TransactionVM>>(), "Permanent")
                        .Returns("OrderReceived");
        var orderService = new OrderService(mockOrderManager.Object);
        orderService.AddOrder(new TransactionVM());
        // Act
        orderService.ProcessOrders();
        // Assert
        mockOrderManager.Verify(_ => _.Receive(It.IsAny<List<TransactionVM>>(),
                                               "Permanent"));
    }
