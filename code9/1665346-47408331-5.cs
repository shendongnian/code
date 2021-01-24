    [TestCaseSource("ProvideTestcases")]
    public void MyTest() { /* ... */ }
    private static IEnumerable<TestCaseData> ProvideTestcases()
    {
        if(RunIfTheSoftwareInstalledOnTheMachine)
            yield return new TestCaseData();
    }
