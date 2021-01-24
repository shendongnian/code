    if (ds.FindAll().Count >= 1)
    {
        var overallSearchResult = ds.FindAll();
        //to apply distinct on path property of elements in the collection
        var uniqueSearchResultsForPath =  overallSearchResult.Cast<System.DirectoryServices.SearchResult>().Select(x => x.Path).Distinct();
    
        //To apply distinct on any specific property in the "Properties" property of the elements in the collection
        //this will give you list of distinct departments for example
        var uniqueSearchResultsForDepartment = overallSearchResult.Cast<System.DirectoryServices.SearchResult>().Select(x => x.Properties["department"][0]).Distinct();
    }
