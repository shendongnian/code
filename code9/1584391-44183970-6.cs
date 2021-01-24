    [TestMethod]
    public void _GetNoficationTest_Expando() {
        // Act.
        var hub = new HubServer();
        var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
        dynamic groups = new ExpandoObject();
        var expected = "Message to send";
        string actual = null;
        var groupName = "Manager";
        bool messageSent = false;
        hub.Clients = mockClients.Object;
        groups.Broadcast = new Action<string>(m => {
            actual = m;
            messageSent = true;
        });
        mockClients.Setup(_ => _.Group(groupName)).Returns((ExpandoObject)groups);
        // Act.
        hub.GetNofication(expected);
        // Assert.
        Assert.IsTrue(messageSent);
        Assert.AreEqual(expected, actual);
    }
