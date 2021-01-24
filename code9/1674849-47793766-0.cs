    public void MapperShouldBeCalledWithCorrectOperationItems()
    {
        // Arrange
        var mapper = Substitute.For<IMapper>();
        var optObj = Substitute.For<IMappingOperationOptions>();
        
        Action<IMappingOperationOptions> argumentUsed = null;
        mapper
            .Map<Result>(Arg.Any<Result>,
                         Arg.Do<Action<IMappingOperationOptions>>(arg => argumentUsed = arg));
    
        // Act
        _uut.DoStuff(new MyInput());
        argumentUsed.Invoke(optObj);
    
        // Assert
        optObj.Items["foo"].Should().Be("bar");
    }
