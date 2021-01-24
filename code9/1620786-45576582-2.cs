    var dict = new Dictionary<string, Predicate<string>>
    {
        ["Product A"] = s => s.StartsWith("C02"),
        ["Product B"] = s => s.EndsWith("X02"),
        ["Product C"] = s => s.Contains("A1700")
    };
    
    string GetProductName(string serialNum)
    {
        foreach(var keyVal in dict)
        {
            if(keyVal.Value(serialNum))
                return keyVal.Key;
        }
        return "No product name found";
    }
    
    List<(string, string)> GetProductNames(string str)
    {
        var productCodes = str.Split(',');
        var productNames = new List<(string, string)>(); // list of tuples (string, string)
    
        foreach(var serialNum in productCodes)
        {
            productNames.Add((serialNum, GetProductName(serialNum)));
        }
    
        return productNames;
    }
