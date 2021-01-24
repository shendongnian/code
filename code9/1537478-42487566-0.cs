    using Moq;
    
    // ARRANGE
    var serviceMock = new Mock<MyService>();
    serviceMock.Setup(s => s.SendEmailAndStopProcessing()).Verifiable();
    // ACT: call myMethod()
    // ASSERT
    const int expectedNumberOfCalls = 1;
    serviceMock.Verify(x => x.SendEmailAndStopProcessing(), Times.Exactly(expectedNumberOfCalls));
