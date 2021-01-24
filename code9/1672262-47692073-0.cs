    public void AddSomething(string ice = "10", string sweet = "20")
    {
        if(ice == "" || ice == null) ice = "10";
        if(sweet == "" || sweet == null) sweet = "20";
        Console.Write(ice);
        Console.Write(sweet);
    }
