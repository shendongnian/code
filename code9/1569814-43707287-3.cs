    [TestMethod]
    public async Task test1() {
       //Arrange
       Item item = new Item(...);
       //Act
       var preview = await Method2(item);
       
       //Assert
       Assert.IsNotNull(preview);      
    }
