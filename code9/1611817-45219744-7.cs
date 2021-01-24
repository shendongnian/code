    [Test]
    public void CheckDirectory_Should_GetFiles() {
        //Arrange
        var files = new [] { 
            "fake path 1",
            "fake path 2",
            //fake path n
        };
        var rootPath = "C:\\Input";
        var service = new Mock<IDirectory>();
        service.Setup(_ => _.GetFiles(rootPath).Returns(files).Verifiable();
    
        var fileUpload = new AvailableFile(service.Object);
    
        //Act   
        fileUpload.GetAvailableFiles(rootPath);
    
        //Assert
        service.Verify();
    }
