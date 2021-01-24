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
