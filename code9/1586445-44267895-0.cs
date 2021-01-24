    [TestCase("bla1")]
    [TestCase("bla2")]
    [TestCase("bla3")]
    public void MyTest(string blaValue)
    {
        _mockObj.MockedMethod(Arg.Any<string>(), Arg.Any<string>())
            .Returns(new objA() { TestProp=blaValue };
        // Your test code
    }
