    [TestMethod]
    public void TestMethod1()
    {
      using (ShimsContext.Create())
      {
        // This is the value to capture whether the NoConfigInit was called
        var initCalled = false;
    
        // Here the DummyMethod comes into play
        Namespace.Fakes.ShimClass3.AllInstances.DummyMethod =
          class3 =>
            typeof(Class3).GetField("_initCalled", BindingFlags.Instance | BindingFlags.NonPublic)
              .SetValue(class3, true);
    
        // This is just a hook to check whether the NoConfigInit is called.
        // You may be able to test this using some other ways (e.g. asserting on state etc.)
        Namespace.Fakes.ShimClass3.AllInstances.NoConfigInit = class3 => initCalled = true;
    
        // act
        new Class3().Initialize();
    
        // assert
        Assert.IsFalse(initCalled);
      }
    }
