    [TestMethod]
    public void TestMethod1()
    {
        var testData = new MyObject
        {
            ID = "Test1",
            Name = "test",
        };
    
        var realObj = new MyClass();
        Isolate.NonPublic.WhenCalled(realObj, "GetServiceData").WillReturn(testData);
        Isolate.NonPublic.WhenCalled(realObj, "SaveAllChanges").CallOriginal();
    
        realObj.MethodToBeTested();
    
        Isolate.Verify.NonPublic.WasCalled(realObj, "SaveAllChanges");
    }
