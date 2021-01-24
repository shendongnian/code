    [TestMethod]
    public void We_Send_System_Exception_On_Email_If_Configured_In_Settings()
    {
        ...
        var logger = new Mock<ApiLogger>(MockBehavior.Default, 
                                         new object[]
                                         {
                                           this._configurationWrapperMock.Object, 
                                           this._mailServiceMock.Object
                                         }).Object;
        logger.OnActionException(...);
        this._mailServiceMock.Verify(
                msm => msm.SendEmailForThrownException(It.IsAny<string>(), It.IsAny<string>()), 
                Times.Once);
    }
