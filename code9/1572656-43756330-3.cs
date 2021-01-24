    using TechTalk.SpecFlow;
    namespace loginTest
    {
        [Binding]
        public class SpecFlowFeature1Steps
        {
            [Given(@"I am in P(.*) login page")]
            public void GivenIAmInPLoginPage(int p0)
            {
                ScenarioContext.Current.Pending();
            }
    
            [Given(@"the user is (.*)")]
            public void GivenTheUserIs(string p0)
            {
                ScenarioContext.Current.Pending();
            }
    
            [When(@"I login")]
            public void WhenILogin()
            {
                ScenarioContext.Current.Pending();
            }
    
            [Then(@"I should see (.*) logo in my account")]
            public void ThenIShouldSeeLogoInMyAccount(string p0)
            {
                ScenarioContext.Current.Pending();
            }
        }
    }
