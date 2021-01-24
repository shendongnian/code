    //Arrange
    var someClassFactoryMock = MockRepository.GenerateMock<ISomeClassFactory>();
    var someClassMock = MockRepository.GenerateMock<ISomeClass>();
    someClassMock.Stub(s => s.Dispose()); // Ignore Dispose
    someClassFactoryMock.Stub(s => s.Get()).Return(someClassMock); // Return mock
    var fooClass = new Foo();
    fooClass.SomeClassFactory = someClassFactoryMock;
    // Act
    fooClass.SomeMethod();
    // Assert
    someClassMock.Expect(s => s.SomeMethod()).Repeat.Times(1); // Assert that it was called once.
