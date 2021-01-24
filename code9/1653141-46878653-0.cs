    public void NestedDictIteration(Dictionary<string,object> nestedDict)
    {
        foreach (string key in nestedDict.Keys)
        {
            Console.WriteLine(key);
            var nextLevel = nestedDict[key];
            if(nextLevel == null)
            {
                continue;
            }
            else (nextLevel is Dictionary<string, object>)
            {
                NestedDictIteration((Dictionary<string, object>)nextLevel);
            }
        }
    } 
