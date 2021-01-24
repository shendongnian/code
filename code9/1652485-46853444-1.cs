    public class TestTemplateData
    {
        // I assume you will use the same action all the time, so just
        // define it here
        private Action<int> square = (int x) => x * x;
        public static IEnumerable HasAccessData
        {
            get
            {
                yield return new TestCaseData
                (
                    // This is the string parameter
                    "Word",
                    // Put whatever parameter you want for your action
                    square(1)
                )
                .SetName("Name of this test case") // Test name
                .Returns(true); // What is the test expected to return
                // You can return multiple test cases this way
                yield return new TestCaseData
                (
                    "Word",
                    square(2)
                )
                .SetName("Name of this test case") // Test name
                .Returns(true); // What is the test expected to return
            }
        }
    }
