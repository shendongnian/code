    [TestMethod]
    public void _OpenTextFile_Should_Return_TextContext_And_FileName() {
        //Arrange
        var expectedFileContent = "Hellow World";
        var expectedFileName = "filename.txt";
        var fileSystem = new Mock<IFileSystem>();
        fileSystem.Setup(_ => _.ReadAllText(expectedFileName, It.IsAny<Encoding>()))
            .Returns(expectedFileContent)
            .Verifiable();
        var openFileDialog = new Mock<IOpenFileDialog>();
        openFileDialog.Setup(_ => _.ShowDialog()).Returns(true).Verifiable();
        openFileDialog.Setup(_ => _.FileName).Returns(expectedFileName).Verifiable();
        var sut = new TextFileService(openFileDialog.Object, fileSystem.Object);
        //Act
        var actual = sut.OpenTextFile();
        //Assert
        fileSystem.Verify();
        openFileDialog.Verify();
        Assert.AreEqual(expectedFileContent, actual.Item1);
        Assert.AreEqual(expectedFileName, actual.Item2);
    }
