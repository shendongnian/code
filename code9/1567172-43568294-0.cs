    static void OnCommandLineParseFail()
    {
        Console.WriteLine("Command line parse failure");
        Console.WriteLine("Help: " + parser.Settings.HelpWriter.ToString());
    }
    static void Main(string[] args)
	{
		try
		{
            StringWriter t = new StringWriter();
		
			var parser = new CommandLine.Parser(s =>
			{
				s.CaseSensitive = true;
                s.HelpWriter = t;
                s.IgnoreUnknownArguments = false;
			});
			// the application unexpectedly stops when calling this method.
			var isValid = parser.ParseArgumentsStrict(args, options, OnCommandLineParseFail);
			if (isValid)
			{
				... run my application here
			}
			else
			{
				Console.WriteLine("Input error.");
			}
		}
		catch(Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
	}
