    [TestMethod]
    public void TestMethod1()
    {
        // Fake the object, Ignore calls, Invoke original ctor
        testClass tc = Isolate.Fake.Instance<testClass>(Members.ReturnNulls, ConstructorWillBe.Called);
        
        // Create a getter for keyValue and call it's original implementation
        Isolate.WhenCalled(() => tc.KeyVal).CallOriginal();
        // Assert that by the end of the ctor keyValue is equal to 221
        Assert.AreEqual(221, tc.KeyVal); 
    }
