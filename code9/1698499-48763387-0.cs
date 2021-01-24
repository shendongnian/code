    for (int i = 30000; i <= 300000; i+=10000)
    {
       var tmp = i;
       testMock.Setup(x => x.MethodA(SomeStaticClass.GetIt(varA, varB, tmp), It.IsAny<int>()))
           .Returns(new List<SomeClass>());
    }
