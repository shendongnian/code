    public void AddSomething(string ice = "10", string sweet = "20")
    {
        MethodBase m = MethodBase.GetCurrentMethod();
        if (ice == "")
            ice = m.ParameterDefault<string>("ice").Value;
        if (sweet == "")
            sweet = m.ParameterDefault<string>("sweet").Value;
        Console.Write(ice);
        Console.Write(sweet);
    }
