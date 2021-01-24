    var AllNumsTB = new HtmlLabel(Browser);
    AllNumsTB.TechnologyName = "Web";
    AllNumsTB.SearchProperties.Add(HtmlControl.PropertyNames.Id, "MainContent_AllNumLbl_Res");
    var result = AllNumsTB.InnerText;
    string result2;
    
    // you may need to include this section, or you may not
    if (result.Length > 0)
    {
    	AllNumsTB.WaitForControlReady();
    	result2 = AllNumsTB.InnerText;
    }
