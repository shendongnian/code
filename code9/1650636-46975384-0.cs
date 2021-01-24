    [Test]
    [TestCaseSource(nameof(TestCaseSourceA))]
    [TestCaseSource(nameof(TestCaseSourceB))]
    public void GivenX_ShouldReturnOk(string input)
    {
        //some test
        Assert.Pass();
    }
    public static IEnumerable<string> TestCaseSourceA()
    {
        yield return "a1";
        yield return "a2";
    }
    public static IEnumerable<string> TestCaseSourceB()
    {
        yield return "b1";
        yield return "b2";
    }
