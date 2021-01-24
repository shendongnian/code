    Dictionary<CombinedKey, List<object>> data = new Dictionary<CombinedKey, List<object>>();
    foreach (var j in GetTopData())
    {
        foreach (var p in BottomData())
        {
            var key = new CombinedKey() { Key1 = j, Key2 = p.Name };
            List<object> list;
            if(!data.TryGetValue(key, out list))
            {
                data[key] = list = new List<object>();
            }
            list.Add(p.Value);
        }
    }
