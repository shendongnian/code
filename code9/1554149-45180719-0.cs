    public class ArgumentsHeader
    {
        public string[] args { get; set; } = new string[0];
        [VerbOption("configure", HelpText = "Sets configuration on server.")]
        public ServerConfigurationArguments ServerConfigurationArguments { get; set; } = new ServerConfigurationArguments();
    
        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            if (verb?.ToLower() == "help" && args.Length > 1)
            {
                verb = args[1];
            }
            return HelpText.AutoBuild(this, verb);
        }
    }
