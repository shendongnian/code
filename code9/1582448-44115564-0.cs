        public struct CRUD
    {
        public bool C;
        public bool R;
        public bool U;
        public bool D;
        public CRUD(bool c, bool r, bool u, bool d)
        {
            this.C = c;
            this.R = r;
            this.U = u;
            this.D = d;
        }
    }
    public enum ActionKind
    {
        Create,
        Read,
        Update,
        Delete
    }
    public struct TestResult
    {
        public ActionKind Action;
        public bool IsPerformed;
    }
    public class TestCase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public CRUD Action { get; set; }
        public List<TestResult> Actual { get; set; }
        public List<TestResult> Expected { get; set; } // or List<TestResult>
    }
    public class Tests
    {
        public void TestAListOfCases()
        {
            var cases = new List<TestCase>
            {
                new TestCase { Name = "Finance", Description = "division with complete test data", Color = "#ff0000",
                    Expected = new List<TestResult> {new TestResult {Action = ActionKind.Create, IsPerformed = true },
                                                     new TestResult {Action = ActionKind.Update, IsPerformed = false},
                                                     new TestResult {Action = ActionKind.Delete, IsPerformed = true }
                    }},
                new TestCase { Name = "IT", Description = "Description"}
            };
            cases
                .Where(x => x.Name == "IT")
                .Where(x => x.Color != "pink")
                .Select(RunTestCase)
                .Where(x => !x.Item2)
                .Select(x => OutputFailedTestCase(x.Item1)); // boah c# is verbose
        }
        public Tuple<TestCase, bool> RunTestCase(TestCase testCase)
        {
            foreach(var exp in testCase.Expected)
            {
                switch (exp.Action) {
                    case ActionKind.Delete:
                        // do delete if needed and create actual result
                        var actual = exp.IsPerformed
                            ? new TestResult { Action = exp.Action, IsPerformed = true }
                            : new TestResult { Action = exp.Action, IsPerformed = false };
                        break;
                    
                }
            }
            var isFailed =
                Enumerable.Zip(
                    testCase.Actual, 
                    testCase.Expected, 
                    (expected, actual) => expected.Action == actual.Action && expected.IsPerformed == actual.IsPerformed)
               .All(x=>x);
            // your selenium stuff
            return Tuple.Create(testCase, isFailed);
        }
        public bool OutputFailedTestCase(TestCase testCase)
        {
            // write to console or do something else
            Console.Write($"{testCase.Name} is failed to perform following actions: {calculateFailedActions}");
            return true;
        }
    }
