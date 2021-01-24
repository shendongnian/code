    var query = sampleList;
    
    if(shouldFilterProperty1)
    {
        query = query.Where(x => x.SampleProperty1.Contains(SearchPattern1));
    }
    if(shouldFilterProperty2)
    {
        query = query.Where(x => x.SampleProperty2.Contains(SearchPattern2));
    }
    
    var result = query.ToList();
