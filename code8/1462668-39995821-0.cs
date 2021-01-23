    public void MethodTobeTested(AbstractFactory factory)
    {
        EntityType entityType = null;
        var syncService = factory.GetSyncService(entityType);
    }
    [TestMethod]
    public void Method_Condition_Result()
    {
        // Arrange
        TestedClass tested = new TestedClass();
        Mock<ISyncService> syncServiceMock = new Mock<ISyncService>();
        Mock<AbstractFactory> factoryMock = new Mock<AbstractFactory>();
        factoryMock.Setup(f => f.GetSyncService(It.IsAny<EntityType>())).Returns(syncServiceMock.Object);
        // Act
        tested.MethodTobeTested(factoryMock.Object);
        // Assert
        // ...
    }
