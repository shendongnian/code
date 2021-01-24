    public virtual ObjectResult<tuser> GetActiveUsers()
    {
        IObjectContextAdapter a = ((IObjectContextAdapter)this); // Breakpoint this line and F11 step through the code, looking at local variables as you go
        var b = a.ObjectContext;
        var c = b.ExecuteFunction<tuser>("GetActiveUsers");
        return c;
    }
