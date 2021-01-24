    [TestMethod]
    public void Duplicate_Added_Should_Return_False {
        //Arrange
        var sut = new GuestResponseRepository();
        var model = new GuestResponse
        {
            Name = "Valheru",
            Email = "valheru@hotmail.com",
            Phone = "12345678",
            WillAttend = true
        };
    
        sut.AddResponse(model);
    
        var expected = false;
    
        //Act
        var actual = sut.AddResponse(model);
    
        //Assert
        Assert.AreEqual(expected, actual);
    }
