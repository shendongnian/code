    [Fact]
    public void TestSheet() {
        // Arrange stuff and mock setup
        var factory = new Mock<IViewModelFactory>();
        factory.Setup(_ => _.CreateNew<ViewModel>(It.IsAny<object[]>()))
               .Returns((object[] args) =>
                   new ViewModel((Character)args[0], (bool)args[1], (bool)args[2])
               );      
    
        // Act
        var result = _controller.Sheet(characterId) as ViewResult;
    
        // Assert
        Assert.NotNull(result);
    
        // assert ViewModel constructor called with x arguments
        factory.Verify(_ => _.CreateNew<ViewModel>(It.IsAny<Character>(), true, true), Times.AtLeastOnce());
    }
