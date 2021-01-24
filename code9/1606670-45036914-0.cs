    using TechTalk.SpecFlow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace MyTestProject
    {
        public static class ScenarioContextExtensions
        {
            public static void MarkStepObsolete(this ScenarioContext scenario, string newStep, params object[] newStepFormatArgs)
            {
                var message = string.Format(@"This step is obsolete. Use '" + scenario.CurrentScenarioBlock + " " + newStep + "' instead.", newStepFormatArgs);
                Assert.Inconclusive(message);
            }
        }
    }
