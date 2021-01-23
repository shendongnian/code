    Dictionary<string, int> textDict = new Dictionary<string, int>();
    int initial = 16;
    
    ...
    
    public string ReplaceText(string stringVal)
    {
        if (!textDict.ContainsKey(stringVal))
            textDict.Add(stringVal, initial + textDict.Count);
        
        return textDict[stringVal];
    }
