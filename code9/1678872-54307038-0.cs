    using System;
    using System.Collections.Generic;
    
    using Xunit;
    
    namespace YourNamespace
    {
        public class XUnitDeferredMemberDataFixture
        {
            private static string testCase1;
            private static string testCase2;
    
            public XUnitDeferredMemberDataFixture()
            {
                // You would populate these from somewhere that's possible only at test-run time, such as a db
                testCase1 = "Test case 1";
                testCase2 = "Test case 2";
            }
    
            public static IEnumerable<object[]> TestCases
            {
                get
                {
                    // For each test case, return a human-readable string, which is immediately available
                    // and a delegate that will return the value when the test case is run.
                    yield return new object[] { "Test case 1", new Func<string>(() => testCase1) };
                    yield return new object[] { "Test case 2", new Func<string>(() => testCase2) };
                }
            }
    
            [Theory]
            [MemberData(nameof(TestCases))]
            public void Can_do_the_expected_thing(
                string ignoredTestCaseName, // Not used; useful as this shows up in your test runner as human-readable text
                Func<string> testCase) // Your test runner will show this as "Func`1 { Method = System.String.... }"
            {
                Assert.NotNull(testCase);
    
                // Do the rest of your test with "testCase" string.
            }
        }
    }
