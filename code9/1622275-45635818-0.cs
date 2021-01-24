    private static IEnumerable<TestCaseData> TestData()
    {
        string uniqueId = Guid.NewGuid().ToString().Substring(0, 8);
        yield return new TestCaseData(uniqueId)
        .SetName("myTest");
    }
