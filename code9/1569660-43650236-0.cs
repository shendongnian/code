    //Mock object creation
    Mock<IExampleInterface> _exampleInterfaceMock = new Mock<IExampleInterface>();
  
    //Setup  
    _exampleInterfaceMock.Setup(x => x.TrackPublicationChangesOnCDS()).Returns(1);
