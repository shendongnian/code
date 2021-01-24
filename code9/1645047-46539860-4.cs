    public object foo(string bar)
    {
        //Some code
    }
    public IEnumerable<object> foo(IEnumerable<string> bar)
    {
        return bar.Select(a => foo(a));
    }
