    public void EventsAcceptSuccessTest() {
        //Arrange
        var eventmodel = new EventsModel() {
            Message = "TEST"
        };
        var repositoryMock = new Mock<IEventsRepository<EventsModel>>();
        repositoryMock
            .Setup(_ => _.GetEventsByEventId(It.IsAny<int>()))
            .Callback((int id) => {
                eventmodel.EventID = id;
                eventmodel.Status = EventStatus.ACCEPTED;
            })
            .Returns(eventmodel);
        var locatorMock = new Mock<IRepositoryLocator>();
        locatorMock.Setup(_ => _.GetRepositoryObject(It.IsAny<string>())).Returns(repositoryMock.Object);
        var subject = new Consumer(locatorMock.Object);
        //Act
        var response = subject.EventsAccept(logMsgId);
        //Assert
        Assert.AreEqual(eventmodel.Status, EventStatus.ACCEPTED);
    }
