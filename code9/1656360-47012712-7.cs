    public static IEnumerable TestCaseSourceMethod()
    {
        foreach (String str in someMethodHere)
        {
            var newString = DoSomeStaff(str);
            yield return new TestCaseData(newString).SetCategory(testCategory);
        }
    }
    public static IEnumerable SpecialTestCaseSourceMethod()
    {
        foreach (String str in someMethodHere)
        {
            var newString = DoSomeStaff(str);
            var otherArgument = GetOtherArgument();
            yield return new TestCaseData(newString, otherArgument).SetCategory(testCategory);
        }
    }
