	public void Main()
	{
        var url = "https://example.com?something=keepMe&foo=FooWasHere&bar=swapMeQuick";
        var dict = new System.Collections.Generic.Dictionary<string, string>();
        dict.Add("foo", null);
        dict.Add("bar", "hello");
        dict.Add("boo", "new");
        Console.WriteLine(CreateUri(url, dict).ToString());
    }
    Uri CreateUri(string uri, IDictionary<string, string> parameters) 
    {
        return CreateUri(new Uri(uri), parameters);
    }
    Uri CreateUri(Uri uri, IDictionary<string, string> parameters)
    {
        var query = HttpUtility.ParseQueryString(uri.Query); //https://msdn.microsoft.com/en-us/library/ms150046(v=vs.110).aspx; though returns HttpValueCollection
        foreach (string key in parameters.Keys)
        {
            if (string.IsNullOrEmpty(parameters[key]))
            { //parameter is null or empty; if such a parameter already exists on our URL, remove it
                query.Remove(key); //if this parameter does not already exist, has no effect (but no exception is thrown)
            }
            else
            { //parameter has a value; add or update the query string with this value
                query.Set(key, parameters[key]);
            }
        }
        var builder = new UriBuilder(uri);
        builder.Query = query.ToString();
        return builder.Uri;
    }
