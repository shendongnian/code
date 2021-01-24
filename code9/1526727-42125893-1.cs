    object[] test = {
            "Rock Parrot",
            "Crimson Rosella",
            "Regent Parrot",
            "Superb Parrot",
            "Red Lory",
            "African Emerald Cuckoo",
            1,2,3};
    
    List<string> s = new List<string>();
    
    foreach (var item in test)
    {
    
        if (typeof(string) == item.GetType())
            s.Add(item.ToString());
    }
