    [Fact]
    public void TestSheet() {
        // Arrange stuff and mock setup
        var factory = new Mock<IViewModelFactory>();
        factory.Setup(_ => _Create(It.IsAny<Character>(), It.IsAny<bool>(), It.IsAny<bool>())
               .Returns((Character model, bool arg2, bool arg3) => 
                   new ViewModel(model, arg2, arg3)
               );        
    
        // Act
        var result = _controller.Sheet(characterId) as ViewResult;
    
        // Assert
        Assert.NotNull(result);
    
        // assert ViewModel constructor called with x arguments
        factory.Verify(_ => _.Create(It.IsAny<Character>(), true, true), Times.AtLeastOnce());
    }
