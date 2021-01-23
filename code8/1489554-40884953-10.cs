    static bool TryGetArg(string commandArguments, string name, out string value)
    {
        // Debug.Assert(name.StartsWith("-"));
        if (commandArguments.Contains("-") &&
            arguments[commandArguments.IndexOf(name) + 1].StartsWith("-") == false)
        {
            value = commandArguments[commandArguments.IndexOf(name) + 1];
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }
