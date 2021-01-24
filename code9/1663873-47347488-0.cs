    public void SomeMethod(string name, [CallerMemberName] string callerName = null)
    {
        Console.Writeline($"SomeMethod was called from {callerName}");
        ...
    }
