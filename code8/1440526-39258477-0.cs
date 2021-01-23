    searchString = searchString.ToLower();
    var properties = list.GetType()
                         .GetGenericArguments()[0].GetProperties()
                         .Where(p => listOfFieldNames.Contains(p.Name))
                         .ToList();
    var query = from listItem in list
                let values = properties.Select(p => p.GetValue(listItem))
                                       .Where(p => p != null)
                                       .Select(p => (p.ToString() ?? "").ToLower())
                where values.Contains(searchString)
                select listItem;
    var matched = query.ToString();
