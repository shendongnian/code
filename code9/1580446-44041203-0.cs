    [Test, TestCaseSource("GetNum")]
    public void Test(int testNum)
    {
    }
    private IEnumerable GetNum
    {
        get
        {
            int numberOfRetries = int.Parse(ConfigurationManager.AppSettings["retryTest"]);
            for (int i = 1; i <= numberOfRetries; ++i)
            {
                yield return new TestCaseData(i);
            }
        }
    }
