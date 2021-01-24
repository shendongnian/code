    [TestCaseSource("TestcaseMethod")] 
    public MyType Check(string value, MyType expected)
    {
        var target = ...
        var actual = target.DoSomething(value);
        bool retVal = // check the properties of actual towards those of expected
        Assert.IsTrue(retVal);
    }
    public IEnumerable<object> TestcaseMethod()
    {
        yield return new object[] { "MyValue", new MyType(/* expected outcome */);
        yield return new object[] { "AnotherValue", new MyType(/* expected outcome */);
    }
