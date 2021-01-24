    var list = urlDictionary.ContainsKey(url.Authority)
        ? urlDictionary[url.Authority]
        : new List<Uri>();
    list.Add(url);
    urlDictionary[url.Authority] = list;
