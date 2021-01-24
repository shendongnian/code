    try
    {
        var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        return Path.Combine(dir, "Logs");
    }
    catch (ArgumentException)
    {
        return "C:\\Logs";
    }
