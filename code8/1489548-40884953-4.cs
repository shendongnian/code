    static bool TryGetArg(string commandArguments, string name, out string value)
    {
        string switchName = "-" + name;
        if (commandArguments.Contains("-") &&
            arguments[commandArguments.IndexOf(switchName) + 1].StartsWith("-") == false)
        {
            value = commandArguments[commandArguments.IndexOf(switchName) + 1];
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }
