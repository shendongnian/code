    //arrange
    string currentStateBeforeRun = "";            
    Mock<IInterfaceToBeMocked> mock = new Mock<IInterfaceToBeMocked>();            
    Sut sut = new Sut(mock.Object);
    mock.Setup(m => m.Run(It.IsAny<int>()))
        .Callback<int>(i => currentStateBeforeRun = sut.CurrentState);           
        
    //act
    sut.MethodUnderTest();
    //assert
    Assert.AreEqual("aaa", currentStateBeforeRun);
