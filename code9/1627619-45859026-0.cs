    [TestMethod]
    public void TestMethod1()
    {
        Service faked = Isolate.Fake.NextInstance<Service>(Members.ReturnRecursiveFakes, ConstructorWillBe.Called);
        ExampleClass exClass = new ExampleClass();
     
        Isolate.WhenCalled(() => faked.SyncMethod(null)).IgnoreCall();
 
        Isolate.Invoke.Method(exClass, "ExecuteProcess");
    }
