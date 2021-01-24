    var queryString = this.Request.GetQueryNameValuePairs();
    List<KeyValuePair<string, object>> QueryStringKeys = new 
    List<KeyValuePair<string, object>>();
    foreach (var pair in queryString)
    {
        QueryStringKeys.Add(new KeyValuePair<string, object>(pair.Key.ToString(), pair.Value));
    }
    Boolean firstvalue = true;
    foreach (var keys in QueryStringKeys)
    {
        //access key.Key and key.Value here to make dynamic query
    }
