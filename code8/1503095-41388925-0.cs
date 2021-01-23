    string GetControlType(HtmlNode n)
    {
        switch (n.Name)
        {
        case "button": return n.GetAttributeValue("type", "(submit)");
        case "input":  return n.GetAttributeValue("type", "(text)");
        default:       return null;
        }
    }
    string GetControlValue(HtmlNode n)
    {
        switch (n.Name)
        {
        case "button":
        case "input":
            return n.GetAttributeValue("value", null);
        case "select":
            if (n.Descendants("option").SkipWhile(x => x.Attributes["selected"] == null).FirstOrDefault() is HtmlNode o) return o.GetAttributeValue("value", null);
            return n.Descendants("option").FirstOrDefault()?.GetAttributeValue("value", null);
        case "textarea":
            return n.InnerText;
        default: return null;
        }
    }
    HtmlNode.ElementsFlags.Remove("form");    
    var doc = new HtmlWeb().Load("http://www.google.com");
    var fields = new[] { "button", "input", "select", "textarea" };
    var query =
        from n in doc.DocumentNode.Descendants()
        where fields.Contains(n.Name)
        let controlType = GetControlType(n)
        let controlValue = GetControlValue(n)
        select new
        {
            ControlName = n.Name,
            ControlType = controlType,
            Name = n.GetAttributeValue("name", null),
            Value = controlValue,
            OuterHtml = n.OuterHtml,
        };
