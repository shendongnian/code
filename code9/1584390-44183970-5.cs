    [TestMethod]
    public void _GetNoficationTest() {
        // Arrange.
        var hub = new HubServer();
        var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
        var groups = new Mock<IClientContract>();
        var message = "Message to send";
        var groupName = "Manager";
        hub.Clients = mockClients.Object;
        groups.Setup(_ => _.Broadcast(message)).Verifiable();
        mockClients.Setup(_ => _.Group(groupName)).Returns(groups.Object);
        // Act.
        hub.GetNofication(message);
        // Assert.
        groups.VerifyAll();
    }
