    // Set the CommandLineParser configuration options.
    var commandLineParser = new CommandLine.Parser(x =>
    {
        x.HelpWriter = null;
        x.IgnoreUnknownArguments = false;
        //x.CaseSensitive = false;
    });
    
    // Parse the command-line arguments.
    CommandLineOptions options;
    var errors = new List<CommandLine.Error>();
    
    var parserResults = commandLineParser.ParseArguments<CommandLineOptions>(args)
        .WithNotParsed(x => errors = x.ToList())
        .WithParsed(x => options = x)
    ;
    
    if (errors.Any())
    {
        errors.ForEach(x => Console.WriteLine(x.ToString()));
        Console.ReadLine();
        return;
    }
