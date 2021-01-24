    var regexDict = new Dictionary<string, Regex>
    {
        ["Product A"] = new Regex("^C02"), //'^' means beginning of string
        ["Product B"] = new Regex("X02$"), //'$' means end of string
        ["Product C"] = new Regex("A1700") //given string anywhere
    };
    
    string GetProductName(string code)
    {
        foreach(var keyVal in regexDict)
        {
            if(keyVal.Value.IsMatch(code))
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
