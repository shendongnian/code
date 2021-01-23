    [TestMethod]
    public void CreateAnotherBadClass_IsNotNull()
    {
        var fakeBadClass = Isolate.Fake.Instance<BadClass>();
        var anotherBadClass = new AnotherBadClass(fakeBadClass);
    
        Assert.IsNotNull(anotherBadClass);
    }
