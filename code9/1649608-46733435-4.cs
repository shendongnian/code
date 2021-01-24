    var xDoc = new XmlDocument();
    xDoc.Load(/* xml path */);
    var els = xDoc.GetElementsByTagName("Nice").Cast<XmlNode>();
    foreach (var el in els)
    {
       Console.WriteLine(el.Attributes.Item(0).Value);
       Console.WriteLine(el.Attributes.Item(1).Value);
    }
