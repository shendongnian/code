    public void DoSomething(int a, int? bOverwrite = null)
    {
        int b = bOverwrite ?? 42;
        // remaining code as before...
    }
