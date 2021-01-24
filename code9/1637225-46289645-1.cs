	[Test]
	public async Task ShouldSendMessage()
	{
	    var endpointInstance = new TestableEndpointInstance();
	    var handler = new MyController(endpointInstance);
	    await handler.HandleRequest()
	        .ConfigureAwait(false);
	    var sentMessages = endpointInstance.SentMessages;
	    Assert.AreEqual(1, sentMessages.Length);
	    Assert.IsInstanceOf<MyMessage>(sentMessages[0].Message);
	}
