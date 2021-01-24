    public void TestMethod()
    {
        var repositoryMock = Substitute.For<IRepository>();
        repositoryMock.GetList().Returns(new List<string> {"str1", "str2"});
        var f_io = new File_IO(repositoryMock);
        var result = f_io.constructString();
        Assert.AreEqual("Expected string", result);
    }
