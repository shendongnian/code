    [TestMethod]
    public void CheckAbstractClassStub()
    {
        var myChild = new StubMyChildClass()
        {
            MyFunctionalBaseClassMethodInt32 = (num) => { return 49; }
        };
        int result = myChild.GetSquare(5);
        Assert.AreEqual(result, 49);
    }
