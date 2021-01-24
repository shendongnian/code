    #addin "nuget:?package=CommandLineParser&version=2.1.1-beta&prerelease=true"
    using CommandLine;
    class Options
    {
        [Option("someparameter",
            HelpText = "Description of the parameter, that can span multiple lines",
            Default = 5)]
        public int SomeParameter { get; set; }
        [Option("nextParameter", HelpText = "Next description")]
        public string NextParameter { get; set; }
        [Option("target", HelpText = "Target", Default = "Default")]
        public string Target { get; set; }
    }
    var helpWriter = new StringWriter();
    var parser = new Parser(config => config.HelpWriter = helpWriter);
        Options options = parser
            .ParseArguments<Options>(
                StringComparer.OrdinalIgnoreCase.Equals(Argument("target", "Default"), "MyDocTask")
                    ? new []{ "--help" }
                    : System.Environment.GetCommandLineArgs()
            )
            .MapResult(
                o => o,
                errors=> new Options { Target = "MyDocTask"} // could capture errors here
        );
        Task("MyDocTask")
            .Does(() => {
                Information(helpWriter.ToString());
        }
        );
        Task("Default")
            .Does(() => {
                Information("SomeParameter: {0}", options.SomeParameter);
                Information("NextParameter: {0}", options.NextParameter);
                Information("Target: {0}", options.Target);
        }
        );
    RunTarget(options.Target);
