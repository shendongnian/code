    [TestCaseSource(nameof(Examples))]
    public void TestCarCost (ExampleInput exampleValue) {
        Car car = new Car(exampleValue);
        return car.GetCost();        
    }
    public IEnumerable<ITestCaseData> Examples {
        get {
            yield return new TestCaseData(new ExampleInput(1,2)).Returns(123.4);
            yield return new TestCaseData(new ExampleInput(3,4)).Returns(567.8);
            yield return new TestCaseData(new ExampleInput(5,6)).Returns(901.2);
        }
    }
