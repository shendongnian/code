    private static void SetValues(string[] keys, string value, IDictionary<string, object> parentDic)
    {
        var key = keys.First();
        var children = keys.Skip(1).ToArray();
        if (children.Any())
        {
            object childObj;
            IDictionary<string, object> childDict;
            if (parentDic.TryGetValue(key, out childObj))
            {
                childDict = (IDictionary<string, object>)childObj;
            }
            else
            {
                childDict = new Dictionary<string, object>();
                parentDic[key] = childDict;
            }
            SetValues(children, value, childDict);
        }
        else
        {
            parentDic[key] = value;
        }
      
    }
