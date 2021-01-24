    Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (var key in Request.QueryString.AllKeys)
        {
            if (key != "a" && key != "b" && key != "c" && key != "d")
            {
                dict.Add(key, Request.QueryString[key]);
            }
        }
    
    queryString = Request.RawUrl.Split(new[] {'?'})[0] +
                  string.Join("&", dict.Select(x => x.Key + "=" + x.Value));
    
    if (!string.IsNullOrEmpty(queryString ))
    {
        queryString  += "&z=6";
    }
