    [TestMethod]
    public void TestKinesisMessage() {
        //Arrange
        var testMessage = "59d6572f028c52057caf13ff";
        var testStream = "testStream";
        var kinesisEvent = BuildKinesisTestRequest(testMessage, testStream);
        var lambdaServiceMock = new Mock<ILambdaContext>();
        var fileUploadServiceMock = new Mock<IFileUploadService>();            
        //Replace the  lazy initialization of the service
        AWSLambdaFileProcessingService.FileUploadService = 
            new Lazy<IFileUploadService>(() => fileUploadServiceMock.Object);
        var subject = new AWSLambdaFileProcessingService();
        //Act
        subject.ProcessKinesisMessageById(kinesisEvent, lambdaServiceMock.Object);
        //Assert
        fileUploadServiceMock.Verify(_ => _.DoSomethingWithKinesisEvent(kinesisEvent), Times.AtLeastOnce());
    }
