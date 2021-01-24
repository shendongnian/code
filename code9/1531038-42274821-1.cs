    [TestMethod] // or whatever attribute your test framework uses
    public void TestInterface()
    {
        const int EXPECTEDID = 42;
        MyTestImplementation testImpl = new MyTestImplementation();
        var sut = new AccountObj(EXPECTEDID, testImpl);
        sut.RefreshAmount();
        // use your assertion methods here
        Assert.IsTrue(testImpl.HasBeenCalled);
        Assert.AreEqual(EXPECTEDID, testImpl.ProvidedID);
    }
