    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    public class TestHelper
    {
        public static bool IsTheSoftwareInstalledOnTheMachine()
        {
            // Return state of software
            return true;
        }
    }
    public class RunIfTheSoftwareInstalledOnTheMachineAttribute : Attribute, ITestAction
    {
        public ActionTargets Targets { get; private set; }
        public void AfterTest(ITest test) {}
        public void BeforeTest(ITest test)
        {
            if (!TestHelper.IsTheSoftwareInstalledOnTheMachine())
            {
                Assert.Ignore("Omitting {0}. Software is not installed on machine.", test.Name);
            }
        }
    }
