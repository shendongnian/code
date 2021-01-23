    public void AnotherBadClassConstructorTest()
    {
        BadClassMock badClassMock = (BadClassMock)FormatterServices.GetUninitializedObject(typeof(BadClassMock));
        badClassMock.InitForTest();
        AnotherBadClass anotherBadClass = new AnotherBadClass(badClassMock);
        Assert.IsNotNull(anotherBadClass);
    }
