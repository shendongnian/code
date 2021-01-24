    var viewNames = xdoc.Root.Elements("viewname").Elements("viewname");
    foreach (var viewName in viewNames)
    {
        var group = new XElement(viewName.Value,
            xdoc.Root.Elements().Where(elem => elem.Element("viewname").Value == viewName.Value));
        group.Save(viewName.Value + ".txt");
    }
