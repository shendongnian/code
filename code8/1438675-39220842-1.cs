      public static ITestCase CreateTestCase(ITestManagementTeamProject project, string title, string desc = "", TeamFoundationIdentity owner = null)
        {
            // Create a test case.
            ITestCase testCase = project.TestCases.Create();
            testCase.Owner = owner;
            testCase.Title = title;
            testCase.Description = desc;
            testCase.Save();
            return testCase;
        }
