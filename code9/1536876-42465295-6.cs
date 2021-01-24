    private static void SetValues(string[] keys, int keyIndex, string value, IDictionary<string, object> parentDic)
    {
        var key = keys[keyIndex];
        if (keys.Length > keyIndex + 1)
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
            SetValues(keys, keyIndex + 1, value, childDict);
        }
        else
        {
            parentDic[key] = value;
        }
    }
