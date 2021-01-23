    public static void GetCompatibility(Dictionary<string, object> paramters)
    {
        foreach (var pair in paramters)
            Console.WriteLine("  {0} = {1}", pair.Key, pair.Value);
    }
    //...
    Dictionary<string, object> paramters = new Dictionary<string, object>
    {
        {"MediaId", 1},
        {"ProductsTypId", 1},
        {"PreviousURL", "http://xxx"},
        {"Request", null},
        {"Width", 123},
        {"Height", 123},
        {"CampaignID", 123},
    };
    GetCompatibility(paramters);
    //...
