    [StepArgumentTransformation]
    public List<FancyName> TransformToFancyName(Table table)
    {
        //create the list from the table contents
    }
    
    [When(@"I add some names")]
    public void AddNames(List<FancyName> names)
    {
        var names = table.CreateSet<FancyName>();
        [...]
    }
