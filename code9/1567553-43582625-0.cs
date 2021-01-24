    [Test]
    public void MyTest()
    {
        Mock<ITestObject> myMock = CreateObject(1);
        ITestObject obj = myMock.Object;
    }
    private Mock<ITestObject> CreateObject(int id)
    {
        Mock<ITestObject> mock = new Mock<ITestObject>();
        mock.SetupGet(o => o.ID).Returns(id);
        return mock;
    }
        
    private interface ITestObject
    {
        int ID { get; set; }
    }
