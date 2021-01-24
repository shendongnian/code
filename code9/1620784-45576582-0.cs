    var dict = new Dictionary<string, Predicate<string>>
    {
        ["Product A"] = s => s.StartsWith("C02"),
        ["Product B"] = s => s.EndsWith("X02"),
        ["Product C"] = s => s.Contains("A1700")
    };
    
    string GetProductName(string str)
    {
        foreach(var keyVal in dict)
        {
            if(keyVal.Value(str))
                return keyVal.Key;
        }
        return "No product name found";
    }
    
    List<string> GetProductNames(string str)
    {
        var productCodes = str.Split(',');
        var productNames = new List<string>();
    
        foreach(var code in productCodes)
        {
            productNames.Add(GetProductName(code));
        }
    
        return productNames;
    }
