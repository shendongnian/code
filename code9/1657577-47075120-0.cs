    #addin nuget:?package=Mono.Options&version=5.3.0.1
    using Mono.Options;
    public static class MyOptions
    {
        public static bool ShouldShowHelp { get; set; } = false;
        public static List<string> Names { get; set; } = new List<string>();
        public static int Repeat { get; set; } = 1;
    }
    var p = new OptionSet {
                { "name=",    "the name of someone to greet.",                          n => MyOptions.Names.Add (n) },
                { "repeat=",  "the number of times to MyOptions.Repeat the greeting.",  (int r) => MyOptions.Repeat = r },
                // help is reserved cake command so using options instead
                { "options",     "show this message and exit",                             h => MyOptions.ShouldShowHelp = h != null },
            };
    try {
        p.Parse (
            System.Environment.GetCommandLineArgs()
            // Skip Cake.exe and potential cake file.
            // i.e. "cake --name="Mattias""
            //  or "cake build.cake --name="Mattias""
            .SkipWhile(arg=>arg.EndsWith(".exe", StringComparison.OrdinalIgnoreCase)||arg.EndsWith(".cake", StringComparison.OrdinalIgnoreCase))
            .ToArray()
        );
    }
    catch (OptionException e) {
        Information("Options Sample: ");
        Information (e.Message);
        Information ("--options' for more information.");
        return;
    }
    if (MyOptions.ShouldShowHelp || MyOptions.Names.Count == 0)
    {
        var sw = new StringWriter();
        p.WriteOptionDescriptions (sw);
        Information(
            "Usage: [OPTIONS]"
            );
        Information(sw);
        return;
    }
    string message = "Hello {0}!";
    foreach (string name in MyOptions.Names) {
        for (int i = 0; i < MyOptions.Repeat; ++i)
            Information (message, name);
    }
