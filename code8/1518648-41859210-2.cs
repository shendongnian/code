    string uri = "http://www.example.com?param1=good&param2=bad";
    string queryString = new System.Uri(uri).Query;
    var queryDictionary = System.Web.HttpUtility
                                .ParseQueryString(queryString);
    var paramsList = new Dictionary<string, string>();
    foreach (var parameter in queryDictionary)
    {
         var key = (string) parameter;
         var value = queryDictionary.Get(key);
         paramsList.Add(key, value);
    }
