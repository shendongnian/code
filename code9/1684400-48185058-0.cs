    var mockExample = new Mock<IExample>();
    
    var hasBeenCalled = false;
    mockExample.Setup(e => e.Foo()).Callback(() => hasBeenCalled = true);
    mockExample.Setup(e => e.FooAsync()).Callback(() => hasBeenCalled = true);
    
    new Thing(mockExample.Object);
    
    Assert.IsTrue(hasBeenCalled);
