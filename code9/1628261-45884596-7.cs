    //Arrange
    var expected = "test25";
    var FakeServerPath = A.Fake<IFilePath>();    
    A.CallTo(() => FakeServerPath.MapPath(A<string>.Ignored, A<string>.Ignored))
     .Returns(expected);
    var sut = new TestTest(FakeServerPath);
    //Act
    var actual = sut.Test1();
    //Assert
    Assert.AreEqual(expected, actual);
