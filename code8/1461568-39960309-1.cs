    [TestMethod, TestCategory("Unit")]
    public async Task Upload_ValidData_Success()
    {
      //other logic to setup mock repository
      //call public method which calls async method
      await engine.UploadAsync(data);
      _mockAllCommandRepository.Verify(x => x.Upload(It.Is<Object>(t => t != null)), Times.Once);
    }
