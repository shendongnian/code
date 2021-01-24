    [TestMethod]
    public void UnitTest_Testing_Letters()
    {
      InitializeUsingLetters();
      // ...
      // The rest of your unit test
      Assert.AreEqual(a, _var1);
    }
    
    [TestMethod]
    public void UnitTest_Testing_Numbers()
    {
      InitializeUsingNumbers();
      // ...
      // The rest of this unit test
      Assert.AreEqual(1, _var4);
    }
    
    private void InitializeUsingLetters()
    {
      _var1 = a;
      // ...
    }
    
    private void InitializeUsingNumbers()
    {
      _var4 = 1;
      // ...
    }
