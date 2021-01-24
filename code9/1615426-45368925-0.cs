    Console.WriteLine("Adding: " + hierarchy.First().Name);
    var metaType = model.Add(hierarchy.First(), true);
    for (int i = 1; i < hierarchy.Count; i++)
    {
        Console.WriteLine("Adding: " + hierarchy[i].Name);
        model.Add(hierarchy[i], true);
        Console.WriteLine("Adding as sub type " + i + " to " + metaType.Type.Name);
        metaType = metaType.AddSubType(i, hierarchy[i]);
    }
