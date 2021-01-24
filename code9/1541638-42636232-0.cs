    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void TestCarCost (int id) 
    {
           
        Car car = new Car(Examples[id]);
        Assert.AreEqual (car.getCost (), Examples[id].cost, "Test " + (i + 1) + " failed");
            
    }
