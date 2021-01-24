    string str =
    @"<?xml version=""1.0""?>
    <sri>
        <item><listingInfo><watchCount>1</watchCount></listingInfo></item>
        <item><listingInfo><watchCount>2</watchCount></listingInfo></item>
    </sri>";
    XDocument xdoc = XDocument.Parse(str);
    var searchResultItems = xdoc.Descendants().Where(x => x.Name.LocalName == "item");
    foreach (var item in searchResultItems)
    {
        var wc = item.XPathSelectElement("listingInfo/watchCount");
        Console.WriteLine(wc.Value);
    }
