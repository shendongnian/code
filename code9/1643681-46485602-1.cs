    Task("Run-Unit-Tests")
        .Does(TestRunner.RunUnitTests);
    RunTarget("Run-Unit-Tests");
    public static class TestRunner
    {
        public static void RunUnitTests(ICakeContext context)
        {
            context.VSTest("./Tests/*.UnitTests.dll");
        }
    }
