    [TestMethod]
    public async Task InsertAsync_Should_Return_Product() {
        //...other code
    
        var expected = new Product { Name = "Added", Description = "Added" };        
        
        var actual = await repository.InsertAsync(expected, userContext);
        Assert.AreEqual(expected.Name, actual.Name);  
    }
