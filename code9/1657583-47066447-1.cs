    [TestMethod]
    public void TestWrite()
    {
        var message = "";
        Action<string> testlog = (string msg) => { message = msg; };
        var writer = new MyClass();
        writer.Log = testlog;
        Assert.AreEqual(message, "List is Empty");
    }
