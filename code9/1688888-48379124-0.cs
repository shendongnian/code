    private IFoo TheMock => CreateMock();
    private IFoo CreateMock()
    {
       var mock = new Mock<IFoo>();
       mock
        .Setup(x => x.DoFooAsync(It.IsAny<Bar>()))
        .Returns(() => Task.FromResult(true));
       return mock.Object;
    }
