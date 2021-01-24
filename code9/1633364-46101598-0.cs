    foreach (string testNaam in testNames)
    {
        CantThinkOfAGoodName(testNaam, row, rownr, ref errorMessages, ref executedTests);
    }
    public static void CantThinkOfAGoodName(string testNaam, KeuringRegel row, int rownr, ref List<string> errorMessages, ref List<Test> executedTests)
    {
        Test test = _Tools_NawContext.Test.Include(item => item.Test2Testmethode).SingleOrDefault(item => item.Naam.Equals(testNaam, StringComparison.OrdinalIgnoreCase));
        AddErrorMessages(test, testNaam, row, rownr, ref errorMessages);
        AddExecutedTests(test, ref executedTests);
    }
    public static void AddErrorMessages(Test test, string testNaam, KeuringRegel row, int rownr, ref List<string> errorMessages)
    {
        if (test == null)
        {
            string testValue = row.testNames[testNaam].ToString();
            if (string.IsNullOrWhiteSpace(testValue) == false)
            {
                errorMessages.Add("Regel " + rownr + ": test.naam '" + testNaam + "' met waarde '" + testValue + "' bestaat niet in db.");
            }
        }
    }
    public static void AddExecutedTests(Test test, ref List<Test> executedTests)
    {
        if (test != null)
            executedTests.Add(test);
    }
