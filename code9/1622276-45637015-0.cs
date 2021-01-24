    private static IEnumerable<TestCaseData> TestData()
    {
        string uniqueId = TestContext.CurrentContext.Random.NextGuid().ToString().Substring(0, 8);
        yield return new TestCaseData(uniqueId);
    }
