    public static IEnumerable SpecialTestCaseSourceMethod()
    {
        foreach (var testcase in TestCaseSourceMethod())
        {
            yield return testcase.AddArguments(otherArgument, extraArgument);
        }
    }
