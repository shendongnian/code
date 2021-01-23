        Dictionary<string, object> myParameter = new Dictionary<string, object>();
        Dictionary<string, object>[] props =
        {
            new Dictionary<string, object> {{"name", "Andres"}, {"position", "Developer"}},
            new Dictionary<string, object> {{"name", "Michael"}, {"position", "Developer"}}
        };
        myParameter.Add("props",props);
