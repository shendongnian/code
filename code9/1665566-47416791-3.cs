    public void Verify_Received_Called() {
        //Arrange
        var channel = new Mock<IChannel>();
        channel
            .Setup(_ => _.Receive())
            .Returns("My mock value here");
    
        var mockProvider = new Mock<IChannelProvider>();
        mockProvider.Setup(_ => _.CreateConnectionAndChannel())
            .Returns(channel.Object);
    
        var controller = new MessageController(mockProvider.Object);
    
        //Act
        var result = controller.Get();
    
        //Assert    
        channel.Verify(_ => _.Receive(), Times.AtLeastOnce);
    } 
