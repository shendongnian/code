    private Command ParseCommand(string commandLine)
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(commandLine));
        var words = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (commandDictionary.ContainsKey(words[0]))
            return commandDictionary[words[0]](words.Skip(1).ParseIntegerArguments());
        throw new SyntaxErrorException($"Unrecognized command '{words[0]}'.");
    }
    private static IEnumerable<int> ParseIntegerArguments(IEnumerable<string> args)
    {
         Debug.Assert(args != null);
         foreach (var arg in args)
         {
             int parsedArgument;
             
             if (!int.TryParse(arg, out parsedArgument))
                 throw new SyntaxErrorException("Invalid argument '{arg}'");
             
             yield return parsedArgument;
         }
    }
