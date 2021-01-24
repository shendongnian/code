    UITestControl AllNumsTB = new UITestControl(Browser);
    AllNumsTB.TechnologyName = "Web";
    AllNumsTB.SearchProperties.Add(HtmlControl.PropertyNames.Id, "MainContent_AllNumLbl_Res");
    
    var result = AllNumsTB.GetProperty(HtmlLabel.InnerText).Trim();
    // var result = AllNumsTB.GetProperty("InnerText").Trim();
