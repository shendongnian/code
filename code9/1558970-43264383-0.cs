    public void BobsLoggingFunction(string fmt, params object[] args) {
        var str = String.Format(fmt, args);
        _file.WriteLine(str);
        Console.WriteLine(str);
    }
