    [When(@"I click the ""(.*)"" anchor")]
    public void WhenIClickTheAnchor(string anchorText)
    {
        ScenarioContext.Current.MarkStepObsolete(@"I click the ""{0}"" link", anchorText);
    }
    [When(@"I click the ""(.*)"" link")]
    public void WhenIClickTheLink(string linkText)
    {
        // ...
    }
