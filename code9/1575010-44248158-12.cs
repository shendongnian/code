    //Arrange
    var sut = new Sut();
    sut.MonitorEvents();
    //Act
    sut.IsServer = "Hello World";
    //Assert
    sut.ShouldRaise("PropertyChanged")
        .WithArgs<PropertyChangedEventArgs>(e => e.PropertyName == string.Empty);
