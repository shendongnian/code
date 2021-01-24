    [TestMethod]
    public void TestMethod1()
    {
        var real = new Foo();
    
        Isolate.WhenCalled(() => real.Apple()).DoInstead(x => { return real.Orange(); });
    
        Assert.AreEqual("Orange", real.Apple());
    }
