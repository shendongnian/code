    [TestMethod]
    public void IsTrackingEventInputValid_When_False_Should_Return_BadRequest() {
        //Arrange
        _mockInputValidation.Setup(x => x.IsTrackingEventInputValid(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
        var expected = ExceptionHandlingMessages.InvalidArgumentException;
        //Act
        var actionResult = _trackingEventController.Events(string.Empty, string.Empty) as BadRequestErrorMessageResult;
        //Assert
        Assert.IsNotNull(actionResult);
        Assert.AreEqual(expected, actionResult.Message);
    }
