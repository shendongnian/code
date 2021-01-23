	foreach(var thing in thingsToDo)
	{
		var objSearchPage = new UITestControl(); //you can also just reinitialize here if it's been previously declared.
		objSearchPage.SearchProperties.Add("yourPropertyHere");
		
		HtmlEdit medit = new HtmlEdit(objSearchPage);     
		medit.SearchProperties.Add("Name", "1$SearchText", PropertyExpressionOperator.Contains);     
		medit.SearchProperties[HtmlEdit.PropertyNames.TagName] = "INPUT";     
		medit.SearchProperties[HtmlEdit.PropertyNames.ControlType] = "Edit";
	}
