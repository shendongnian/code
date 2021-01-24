    var items = new List<EbayDataViewModel>();
    XDocument xdoc = XDocument.Load(url);
    // Since you're only interested in <item> collections within <searchResult>
    var searchResultItems = xdoc.Descendants()
        .Where(x => x.Name.LocalName == "item");
    foreach (var sri in searchResultItems)
    {
       // Get all child xml elements
       var childElements = sri.Elements();
       var itemId = childElements.SingleOrDefault(x => x.Name.LocalName == "itemId");
       var title = childElements.SingleOrDefault(x => x.Name.LocalName == "title");
       //add items from xml data to EbayDataViewModel object
        items.Add(new EbayDataViewModel {
            EbayTitle = title == null? Stirng.Empty : title.Value,
            ...
        });
    }
    return items;
