    Dictionary<string, string> dicUnion = dic1;
    foreach(var item in dic2)
    {
        if(dicUnion.ContainsKey(item.Key))
        {
            dicUnion[item.Key] += " " + item.Value;
        }
        else
        {
            dicUnion.Add(item.Key, item.Value);
        }
    }
