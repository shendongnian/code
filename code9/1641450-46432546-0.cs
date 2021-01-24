    var mock = new Mock<ITarget>();
    var mCalls = new List<string>();
    mock.Setup(t => t.A(It.IsAny<string>()).Callback(s => mCalls.Add(s));
    
    //... act
    
    //assert
    //inspect what is in mCalls
