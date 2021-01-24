    // you only have to set this up once
    var lookup = new Dictionary<string, int>()
    {
        ["objectbla"] = 1,
        ["objectblabla"] = 2,
        ["objectetc"] = 3,
        ["objectanother"] = 4,
        ["objectobj"] = 5,
    };
    // actual logic
    if (lookup.TryGetValue(objectname, out var objectId))
    {
        DoSomething(objectId, objectName, someOtherVar);
    }
    else
    {
        // objectname is not in the lookup dictionary
    }
