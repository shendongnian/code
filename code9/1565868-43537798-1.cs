    //single item
    var widget = AvailableWidgets.GetById(id);
    //single property
    var title = widget?.Title;
    //query
    var matchingWidgets = AvailableWidgets.All.Where(w => w.Title.Contains("Foo"));
