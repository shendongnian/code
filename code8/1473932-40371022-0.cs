    Dictionary<string, ObjectData> groups = new Dictionary<string, ObjectData>();
    groups.Add("NC_Test1", new ObjectData());
    groups.Add("NC_Test2", new ObjectData());
    groups.Add("Test3", new ObjectData());
    groups.Add("NC_Test4", new ObjectData());
    groups.Add("Test5", new ObjectData());
    groups.Add("NC_Test6", new ObjectData());
    Dictionary<string, ObjectData> groupsclustered = new Dictionary<string, ObjectData>();
    groups.ToList().ForEach( x => {
        string newKey;
        newKey = x.Key.StartsWith(@"NC_") ? x.Key.Substring(3) : x.Key;
        if (groupsclustered.ContainsKey(newKey))
        { groupsclustered[newKey] = x.Value; } else { groupsclustered.Add(newKey, x.Value); }
    } );
