    [TestMethod]
    public void WriteToOutput_NullableList_ThrowNullReferenceException()
    {
        var message = "";
        Action<string> testlog = (string msg) => { message = msg; };
        var writer = new FileWriter();
        writer.Log = testlog;
        Assert.AreEqual(message, "List is Empty");
    }
