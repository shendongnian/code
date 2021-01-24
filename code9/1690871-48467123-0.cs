    [Test]
    public void Get_ReturnsAConsumer_WithAListOfIProvider()
    {
      var mockRepo = new Mock<IProvider<Consumer>>();
      mockRepo.Setup(repo => repo.GetAll()).Returns(GetConsumers());
      var controller = new ConsumersController(mockRepo.Object);
      var result = controller.Get();
      Assert.IsAssignableFrom<List<Consumer>>(result);
      Assert.AreEqual(1, result.Count());
    }
