    public Command ParseCommand(string commandLine)
    {
        var words = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        Debug.Assert(words.Length > 0);
        if (commandDictionary.ContainsKey(words[0]))
            return commandDictionary[words[0]](words.Skip(1).ParseIntegerArguments());
        throw new SyntaxErrorException($"Unrecognized command '{words[0]}'.");
    }
    private static IEnumerable<int> ParseIntegerArguments(IEnumerable<string> args)
    {
         foreach (var arg in args)
         {
             int parsedArgument;
             
             if (!int.TryParse(arg, out parsedArgument))
                 throw new SyntaxErrorException("Invalid argument '{arg}'");
             
             yield return parsedArgument;
         }
    }
