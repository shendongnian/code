    List<A> allAs = new List<A>();
    allAs.Add(new A(10, "CAR"));
    allAs.Add(new A(22, "BUS"));
    allAs.Add(new A(100, "TRAIN"));
    allAs.Add(new A(0, "HYPERLOOP"));
    Dictionary<string, int> nameweight = new Dictionary<string, int>() 
    {
        { "HYPERLOOP", 1 }, 
        { "TRAIN", 2 }, 
        { "CAR", 3 }, 
        { "BUS", 4 }
    };
    allAs = allAs.OrderBy(x => nameweight[x.name]).ToList();
