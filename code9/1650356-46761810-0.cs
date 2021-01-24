        class Options
        {
            [Option("account-name", Required = true, HelpText = "Name of the account to use")]
            public string AccountName { get; set; }
            [Option("single-file", HelpText = "Use one file as output")]
            public bool SingleFile { get; set; }
            [Option("excel-timestamps", DefaultValue = false, HelpText = "If set, timestamps will be printed with no timezone information in a format recognisable by Excel")]
            public bool ExcelTimestamps { get; set; }
            [ParserState]
            public IParserState LastParserState { get; set; }
            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this,
                  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }
