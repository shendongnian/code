    var attrs = new HashSet<string>("attr2,attr3".Split(','));
    foreach (var e in output.Descendants("element"))
        e.Attributes().Where(a => !attrs.Contains(a.Name.LocalName)).Remove();
    // or simply
    output.Descendants("element")
        .Attributes()
        .Where(a => !attrs.Contains(a.Name.LocalName))
        .Remove();
