    List<Uri> list = null;
    if (!urlDictionary.TryGetValue(url.Authority, out list))
    { 
        list = new List<Uri>();
        urlDictionary[url.Authority] = list;
    }
    list.Add(url);
