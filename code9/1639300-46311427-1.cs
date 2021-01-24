    [TestMethod]
    public void TestMethod1() 
    {
    
        int insurance = 500;
        Budget b = BudgetManager.CreateBudget(insurance);
    
        Assert.AreEqual(insurance, b.Car.Insurance);
    }
    
