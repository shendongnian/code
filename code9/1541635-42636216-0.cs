    [TestCase("Example Value 1", ExpectedResult=123.4)]
    [TestCase("Example Value 2", ExpectedResult=567.8)]
    [TestCase("Example Value 3", ExpectedResult=901.2)]
    public void TestCarCost (string exampleValue) {
        Car car = new Car(exampleValue);
        return car.GetCost();        
    }
