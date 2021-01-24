    [TestMethod]
    public void _SendNotificationTest() {
        // Arrange
        var notificationInput = new NotificationInput();
        notificationInput.CId = "CUST001";
        notificationInput.CName = "Toney";
        var groupName = "GroupName";
        var message = "notification";
        var mockGroups = new Mock<IClientContract>();
        mockGroups.Setup(_ => _.BroadcastCustomerGreeting(message)).Verifiable();
        var mockClients = new Mock<IHubConnectionContext<dynamic>>();
        mockClients.Setup(_ => _.Group(groupName)).Returns(mockGroups.Object).Verifiable();
        var mockHub = new Mock<IHubContext>();
        mockHub.Setup(_ => _.Clients).Returns(mockClients.Object).Verifiable();
        var mockHubProvider = new Mock<IHubContextProvider>();
        mockHubProvider.Setup(_ => _.Hub).Returns(mockHub.Object);
        var controller = new NotificationController(mockHubProvider.Object);
        // Act
        var actionResult = controller.SendNotification(notificationInput);
        //Assert
        mockClients.Verify();
        mockGroups.Verify();
        mockHub.Verify();
    }
