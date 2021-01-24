    [Test, TestCaseSource(nameof(MyTestCases))]
    public void TestMethod(object obj)
    {
    }
    private static readonly object[] MyTestCases =
    {
        new object { TestProp="bla1" },
        new object { TestProp="bla2" },
        new object { TestProp="bla3" },
    };
