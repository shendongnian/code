    public static Event GetMockedEvent()
    {
        var mock = new Mock<Event>();
        mock.Setup(e => e.IsValid).Returns(true);
        mock.As<IEnumerable<Message>>()
            .Setup(e => e.GetEnumerator())
            .Returns(() => MessageList());
    
        return mock.Object;
    }
