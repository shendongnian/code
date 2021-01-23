    Factory.Assign<DateTime>("date");
    
    // later on, you can retrieve value using this:
    // assume query is "Date=01/01/2001"
    Dictionary<string, object> queryStringValues = new Dictionary<string, object>();
    foreach (string key in Request.QueryString.AllKeys) 
    {
        queryStringValues.Add(key, Factory.Retrieve(key, Request.QueryString[key]));
    }
