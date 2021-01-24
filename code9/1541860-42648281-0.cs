     [TestMethod]
    public void TestMethod1()
    {
        A classUnderTest = new A();
        string larger = "blablablabla", smaller = "b";
    
        Isolate.NonPublic.WhenCalled(classUnderTest,"CompareTwoRefStrings").AssignRefOut(smaller, larger).CallOriginal();
    
        var result = classUnderTest.RefPrivateMethod();
    
        Assert.AreEqual(larger, result);
    }
