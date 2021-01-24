    public class SharedState
    {
        public Window Window {get;set;}
        public Application Application {get;set;}
    }
  
	[Binding]
	public class Hooks1
	{
		private SharedState _sharedState;
	
		public Hooks1(SharedState sharedState)
		{
			_sharedState = sharedState;
		}
		
		
		[BeforeScenario("run")]
		public void BeforeScenario()
		{
			_sharedState.Application = Application.AttachOrLaunch(new ProcessStartInfo("C:\\Program Files (x86)\\Tests\\directory\\Test.exe"));
			_sharedState.Window = _sharedState.Application.GetWindow(SearchCriteria.ByClassName("TGUI"), InitializeOption.NoCache);
		}
		[AfterScenario]
		public void AfterScenario()
		{
			_sharedState.Window.Close();
		}
	}
	
	[Binding]
    public class TestSequenceSteps
    {
		private SharedState _sharedState;
	
		public TestSequenceSteps(SharedState sharedState)
		{
			_sharedState = sharedState;
		}
        
        [Given(@"I have opened Test")]
        public void GivenIHaveOpenedTest()
        {
        }
        [When(@"I press Test button")]
        public void WhenIPressTestButton()
        {
            var button = _sharedState.Window.Get<Button>(SearchCriteria.ByClassName("TButton"));
            button.Click();
        }
        [When(@"I press Continue button")]
        public void WhenIPressContinueButton()
        {
            var button = _sharedState.Window.Get<Button>(SearchCriteria.ByText("ContinueButton"));
            Thread.Sleep(700);
            button.Click();
        }
        [Then(@"test sequnce is run")]
        public void ThenTestSequnceIsRun()
        {
            //ScenarioContext.Current.Pending();
        }
    }
