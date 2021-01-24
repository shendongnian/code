    public void DoSomething (char symbol)
    {
        DoThis()
    }
    public void DoSomething (char symbol, Action<string> execute)
    {
        if (execute == null) /* handle null case */ 
            DoThis()
        else 
            DoThat()
    }
