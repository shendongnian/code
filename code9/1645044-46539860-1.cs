    public object foo(string bar)
    {
        //Some code
    }
    public object foo(IEnumerable<string> bar)
    {
        foreach (var s in bar) foo(s);
    }
