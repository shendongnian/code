    [TestMethod, TestCategory("Unit")]
    public void Upload_ValidData_Success()
    {
      //other logic to setup mock repository
      //call public method which calls async method
      AsyncContext.Run(() => engine.Upload(data));
      _mockAllCommandRepository.Verify(x => x.Upload(It.Is<Object>(t => t != null)), Times.Once);
    }
