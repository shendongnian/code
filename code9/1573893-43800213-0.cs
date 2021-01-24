    // create your sample list
    List<SampleClass> sampleList = new List<SampleClass>();
    sampleList.Add(...) 
    
    // create the filter
    Dictionary<string, string> Filter = new Dictionary<string, string>();
    Filter.Add("SampleProperty1", "SearchPattern1");
    Filter.Add("SampleProperty5", "SearchPattern5");
    
    // create the linq query
    var query = sampleList.AsEnumerable();    
    foreach(var filterItem in Filter)
    {   
        // get the property you want to filter
        var propertyInfo = typeof(SampleClass).GetProperty(filterItem.Key);
        
        // add the filter to your query
        query = query.Where(x => (string)propertyInfo.GetValue(x) == filterItem.Value);
    }
    
    // execute the query
    var resultList = query.ToList();
