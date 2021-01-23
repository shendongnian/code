    public delegate void CommandDelegate(string input);
    public Dictionary<string, CommandDelegate> Commands { get; set; }
    /// usage
    public void InitCommands() 
    {
        Commands.Add("showdata", (input) => Console.WriteLine(....));
        ... // other commands
    }
    public void ExecuteCommand(string userInput) 
    {
        var firstWord = userInput.Substring(0, userInput.IndexOf(" "));
        if (Commands.ContainsKey(firstWord)) 
        {
             var command = Commands[firstWord];   
             command(userInput);
        }
    }
    
