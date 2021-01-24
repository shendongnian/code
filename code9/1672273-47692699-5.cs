    public void AddSomething(string ice = "10", string sweet = "20")
    {
        MethodBase m = MethodBase.GetCurrentMethod();
        if (ice == "")
            ice = m.ParameterDefault<string>(nameof(ice)).Value;
        if (sweet == "")
            sweet = m.ParameterDefault<string>(nameof(sweet)).Value;
        Console.Write(ice);
        Console.Write(sweet);
    }
