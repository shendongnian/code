    public void AddSomething(string ice = "10", string sweet = "20")
    {
        if(string.IsNullOrEmpty(ice)) ice = "10";
        if(string.IsNullOrEmpty(sweet)) sweet = "20";
        Console.Write(ice);
        Console.Write(sweet);
    }
