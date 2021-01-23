    //Arrange
    var expected = 2;
    var actual = -1;
    var loader = Substitute.For<ILoader>();
    loader.LoadAsync(Arg.Do<List<int>>(x => actual = x.Count);
    var sut = new SystemUnderTest(loader);
    //Act
    await sut.InvokeAsync(expected);
     
    //Assert
    Assert.Equal(expected, actual);
