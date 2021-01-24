    var regexDict = new Dictionary<string, Regex>
    {
        ["Product A"] = new Regex("^C02"), //'^' means beginning of string
        ["Product B"] = new Regex("X02$"), //'$' means end of string
        ["Product C"] = new Regex("A1700") //given string anywhere
    };
    
    string GetProductName(string serialNum)
    {
        foreach(var keyVal in regexDict)
        {
            if(keyVal.Value.IsMatch(serialNum))
                return keyVal.Key;
        }
        return "No product name found";
    }
    List<(string, string)> GetProductNames(string str)
    {
        var productCodes = str.Split(',');
        var productNames = new List<string>();
    
        foreach(var serialNum in productCodes)
        {
            productNames.Add((serialNum, GetProductName(serialNum)));
        }
    
        return productNames;
    }
