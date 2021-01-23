    [Given(@"I'm on the homepage")]
    public void GivenImOnTheHomepage()
    {
        go to homepage...
    }
    [When(@"When I click some button")]
    public void WhenIClickSomeButton()
    {
        click button...
    }
    [Then(@"Something Special Happens")]
    public void ThenSomethingSpecialHappens()
    {
        var theRightThingHappened = someWayToTellTheRightThingHappened();
        var result = Assert.IsTrue(theRightThingHappened);
        if(!result)
        {
           thenTrySomeStepsAgainHere and recheck result using another assert
        }
    }
