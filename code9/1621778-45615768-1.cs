    var dictionary = new Dictionary<string, List<string>>();
    foreach(var res in resource)
    {
        var key = res.FirstName + res.LastName;
        
        List<string> value;
        if ( dictionary.TryGetValue(key, out value))
        {
            value.Add(res.Lan);
        }
        else
        {
            dictionary[key] = new List<string> {res.Lan};
        }
    }
