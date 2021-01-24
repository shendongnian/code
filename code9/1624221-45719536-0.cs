    public static List<MyKeyValuePair> GetClientValues(dynamic content)
    {
        var myList = new List<MyKeyValuePair>();
        foreach (var kv in content.values)
        {
            myList.Add(new MyKeyValuePair {
                Id = int.Parse(kv.Key),
                Description = kv.Value
            });
        }
        return myList;
    }
