    public Command ParseCommand(string commandLine)
    {
        var words = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        Debug.Assert(words.Length > 0);
        if (commandDictionary.ContainsKey(words[0]))
            return commandDictionary[words[0]](words.Skip(1).ParseIntegerArguments());
        //Unrecognized Command
        throw new SyntaxErrorException();
    }
    private static IEnumerable<int> ParseIntegerArguments(IEnumerable<string> args) { ... }
