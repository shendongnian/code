       public class test
        {
            public static string GetData()
            {
                //Wish to mock TestResult method
                TestData TD = new TestData();
                string FinalResult = TD.TestResult();
                //Some logic
                return FinalResult;
            }
            public class TestData
            {
                public string TestResult()
                {
                    return "Hello World";
                }
            }
        }
