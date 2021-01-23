    [TestMethod]
    public void TestMethod()
    {
        //mock the future instances of Iclac 
        //and when the next NormalClac will be created it will be mocked as well
        var fakeIclac = Isolate.Fake.NextInstance<ICalc>();
    
        //setting the behavior of GetSum
        Isolate.WhenCalled(() => fakeIclac.GetSum(0, 0)).WillReturn(5);
    
        var result = new SalaryManager().DoCalculation(0, 0);
    
        Assert.AreEqual(5, result);
    } 
   
