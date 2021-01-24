    string currentState = "";
    Mock<IInterfaceToBeMocked> mock = new Mock<IInterfaceToBeMocked>();
    mock.Setup(m => m.Run(It.IsAny<int>()))
        .Callback<int>(i => currentState = "something");
    mock.SetupGet(p => p.CurrentState)
        .Return(() => currentState)
