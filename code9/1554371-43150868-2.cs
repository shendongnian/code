    [AfterStep]
    public void Check()
    {
        if (ScenarioContext.Current.TestError is AssertionException &&
            ScenarioContext.Current.CurrentScenarioBlock == ScenarioBlock.Given)
            Assert.Inconclusive(ScenarioContext.Current.TestError.Message);
    }
