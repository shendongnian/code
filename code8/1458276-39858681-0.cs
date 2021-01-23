    foreach(var thing in thingsToDo)
    {
        HtmlEdit medit = new HtmlEdit(objSearchPage);     
        medit.SearchProperties.Add("Name", "1$SearchText", PropertyExpressionOperator.Contains);     
        medit.SearchProperties[HtmlEdit.PropertyNames.TagName] = "INPUT";     
        medit.SearchProperties[HtmlEdit.PropertyNames.ControlType] = "Edit";
        // use medit now and it will work
    }
