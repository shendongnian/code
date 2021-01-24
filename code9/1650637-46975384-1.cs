    [Test]
    [TestCaseSource(nameof(TestCaseSourceMaster))]
    public void GivenX_ShouldReturnOk(string input, string fromOddsStyle, string toOddsStyle)
    {
        //some test
        Assert.Pass();
    }
    public static IEnumerable<string[]> TestCaseSourceMaster()
    {
        return TestCaseSourceA()
            .Concat(TestCaseSourceB())
            .SelectMany(t => new string[][]
            {
                new string[]{t,"US","Eur"},
                new string[]{t,"Eur","Us"}
            });
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
