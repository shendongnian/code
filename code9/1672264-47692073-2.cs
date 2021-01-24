    const string DefaultSweet = "20";
    const string DefaultIce = "10";
    public void AddSomething(string ice = DefaultSweet, string sweet = DefaultIce)
    {
        if(string.IsNullOrEmpty(ice)) ice = DefaultIce;
        if(string.IsNullOrEmpty(sweet)) sweet = DefaultSweet;
        Console.Write(ice);
        Console.Write(sweet);
    }
