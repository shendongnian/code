    [TestMethod]
    public void Abc_log_Test() {
        //Arrange
        string filename = "fakeFile.txt";
        string expected = @"C:\" + filename;
        var mockServerPath = new Mock<IServerPath>();
        mockServerPath
            .Setup(m => m.MapPath(filename))
            .Returns(expected)
            .Verifiable();
        Abc.ServerPath = mockServerPath.Object;
        var message = "Hello world";
        //Act
        Abc.log(message);
     
        //Assert
        mockServerPath.Verify();
    }
