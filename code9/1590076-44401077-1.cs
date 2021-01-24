    private class TestSubClass : YourAbstractBase { }
    public void TestMethod()
    {
        // arrange
        var testObj = new TestSubClass();
        // act
        var result = testObj.YourVirtualMethod();
        // assert
        Assert.AreEqual(123, result);
    }
