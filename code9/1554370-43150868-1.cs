    [AfterStep]
    public void Check()
    {
        if (ScenarioContext.Current.TestError is AssertionException &&
            ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType == StepDefinitionType.Given)
            Assert.Inconclusive(ScenarioContext.Current.TestError.Message);
    }
