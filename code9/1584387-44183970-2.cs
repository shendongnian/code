    [TestMethod]
    public void _GetNoficationTest_Expando() {
        // Act.
        var hub = new HubServer();
        var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
        dynamic groups = new ExpandoObject();
        var message = "Message to send";
        var groupName = "Manager";
        bool messageSent = false;
        hub.Clients = mockClients.Object;
        groups.Broadcast = new Action<string>(m => {
            messageSent = m == message;
        });
        mockClients.Setup(_ => _.Group(groupName)).Returns((ExpandoObject)groups);
        // Act.
        hub.GetNofication(message);
        // Assert.
        Assert.IsTrue(messageSent);
    }
