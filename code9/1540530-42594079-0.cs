    // implementing multiple interfaces in mock
    var foo = new Mock<IFoo>();
    var disposableFoo = foo.As<IDisposable>();
    // now the IFoo mock also implements IDisposable :)
    disposableFoo.Setup(df => df.Dispose());
    
    //implementing multiple interfaces in single mock
    var foo = new Mock<IFoo>();
    foo.Setup(f => f.Bar()).Returns("Hello World");
    foo.As<IDisposable>().Setup(df => df.Dispose());
