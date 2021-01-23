    for (var i = 0; i < 10; i++)
    {
        Logger.BeginScope("scope_" + i);               
        Logger.Log("test");
        Logger.BeginScope("inner scope_" + i);
        Logger.Log("test");                
        Logger.EndScope();
        Logger.Log("test"); // back to scope_i
        Logger.EndScope();
    }
