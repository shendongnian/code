    [TestMethod]
    public void Test()
    {
        A a = new A();
        a.AddNewB(DateTime.Now);    
        a.AddNewB(DateTime.Now); 
            
        Assert.AreEqual(2, a.GetAllBs().Count);
    }
