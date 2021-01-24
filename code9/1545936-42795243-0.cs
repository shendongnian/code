    string[] lines = input.Split('\n');
    var myDict = new Dictionary<string, Dictionary<string,string>>();
    var currentKey = "";
    
    foreach (string[] keyVal in lines.Where(line=>!string.IsNullOrWhiteSpace(line))
                                     .Select(line => line.Split('='))) 
    {
        if (keyVal[0].StartsWith("ID"))
        {
            currentKey = keyVal[1].Trim();
            myDict.Add(currentKey, new Dictionary<string, string>());
        }
        else
        {
            myDict[currentKey].Add(keyVal[0].Trim(), keyVal[1].Trim());
        }
    }
