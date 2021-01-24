    var items = new List<EbayDataViewModel>();
    XDocument xdoc = XDocument.Parse(new WebClient().DownloadString(xmlResponse));
    // Since you're only interested in <item> collections within <searchResult>
    var searchResultItems = xdoc.Descendants()
        .Where(x => x.Name.LocalName == "item");
    foreach (var sri in searchResultItems)
    {
       //add items from xml data to EbayDataViewModel object
        items.Add(new EbayDataViewModel {
            ...
        });
    }
    return items;
