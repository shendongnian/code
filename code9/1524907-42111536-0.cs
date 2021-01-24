    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    
    namespace ClassLibrary3
    {
        [Binding]
        public class MySteps : Steps
        {
            [Given("Doing some actions, getting (.*)  and (.*)")]
            public void DoingSomeActionsGettingValueAndOtherValue(int a, int b)
            {
                Given($"I pass first integer {a} and second integer {b}");
            }
    
            [Given(@"I pass first integer (.*) and second integer (.*)")]
            public void ThenIPassFirstIntegerValueAndSecondIntegerValue(int a, int b)
            {
                Assert.AreEqual(a, b);
            }
        }
    }
