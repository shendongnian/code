    Options options = parser
        .ParseArguments<Options>(
            StringComparer.OrdinalIgnoreCase.Equals(Argument("target", "Default"), "MyDocTask")
                ? new []{ "--help" }
                : System.Environment.GetCommandLineArgs()
        )
        .MapResult(
            o => o,
            errors=> new Options { Target = "MyDocTask"} // TODO capture errors here
    );
