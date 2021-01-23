    public void AnotherBadClassConstructorTest()
    {
        BadClassMock badClassMock = Mock.Create<BadClassMock>();
        AnotherBadClass anotherBadClass = new AnotherBadClass(badClassMock);
        Assert.IsNotNull(anotherBadClass);
    }
