    // doing the .ToLower() on searchString before the query will improve performance.  
    // The original form would execute each pass (as a note .ToUpper() is slightly faster for 
    // conversions and comparisons since upper case letter come before lower case.
    searchString = searchString.ToLower();
    // assuming `list` is a List<T> this will allow the inner type of be used to get the 
    // property list. It is possible to check that getters exist for the properties which 
    // may be helpful if you have any setter only properties. If you work with any languages
    // other than C# you may also want to exclude properties with indexers.
    var properties = list.GetType()
                         .GetGenericArguments()[0].GetProperties()
                         .Where(p => listOfFieldNames.Contains(p.Name))
                         .ToList();
    var query = from listItem in list
                // if you have any setter only properties p.GetValue() will cause an exception
                let values = properties.Select(p => p.GetValue(listItem))
                                       .Where(p => p != null)
                // you probably don't see the null coalesce but it is possible that .ToString()
                // was over ridden and could allow null. The empty string is simplier to inline
                // than to add another null filter after the .ToString()
                                       .Select(p => (p.ToString() ?? "").ToLower())
                // this will allow you to compare all properties that had values to your search
                where values.Contains(searchString)
                select listItem;
    // this will create a new list that will contain all of the values from list that had at 
    // least one property that matched your searc hstring
    var matched = query.ToList();
