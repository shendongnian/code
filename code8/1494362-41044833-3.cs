    [Fact]
    public void Given_Input_SomeMethodThatUsesMyService_Should_Increase_By_Ten() {
        //Arrange
        var expected = 14;
    
        var mock = new Mock<IMyService>();
    
        mock.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((x, y) => { return x + y; });
    
        var svc = mock.Object;
    
        var sut = new SomeClass(svc);
    
        //Act
        var result = sut.SomeMethodThatUsesMyService(4);
    
        //Assert
        result.Should().Be(expected);
    }
