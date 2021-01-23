    //Arrange
    //Instantiate options and nested classes
    //making assumptions here about nested types
    var options = new AbOptions(){
        cc = new cc {
            D1 = //...some value
        }
    };
    var mock = new Mock<IOptionsSnapshot<AbOptions>>();
    mock.Setup(m => m.Value).Returns(options);
    
    var service = new AbClass(mock.Object);
