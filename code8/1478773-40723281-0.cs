	var parent = FindListById(browser, "list");
	var child1 = parent.GetChildren()[0]; // this is 1st child of UL with id=list, in your case first John Smith
	var child2 = parent.GetChildren()[1]; // this is 2nd child of UL with id=list, in your case second John Smith
	Mouse.Click(child2);
    public HtmlList FindListById(UITestControl parent, string id)
    {
        var parentlist= new HtmlList(parent);
        parentlist.SearchProperties.Add(HtmlList.PropertyNames.Id, id);
        return parentlist;
    }
