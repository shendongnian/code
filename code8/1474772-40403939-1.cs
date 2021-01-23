    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        var sourceSwitch = new SourceSwitch("DefaultSourceSwitch");
        sourceSwitch.Level = SourceLevels.Information;
        loggerFactory.AddTraceSource(sourceSwitch, new TextWriterTraceListener(writer: Console.Out));
    }
