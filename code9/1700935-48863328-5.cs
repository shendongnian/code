    [Test]
    public async Task EnsureFoo()
    {
         // Arrange
         // Act
         var myResult = await classBeingTested.DoSomethingAsync();
         // Assert
         Assert.IsNotNull(myResult);
         ...
    }
