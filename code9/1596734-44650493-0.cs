    public SerilogHelper()
    {
        string minLevel = SSOSettingsFileManager.SSOSettingsFileReader.ReadString(
          "LCC.Common", "serilog.level");
        string conString = SSOSettingsFileManager.SSOSettingsFileReader.ReadString(
          "LCC.Common", "serilog.connectionstring");
        this.Initialize(conString, minLevel);
    }
    public SerilogHelper(string conString, int minLevel)
    {
        this.Initialize(conString, minLevel);
    }
    protected void Initialize(string conString, int minLevel)
    {
        var levelSwitch = new LoggingLevelSwitch();
        levelSwitch.MinimumLevel = (Serilog.Events.LogEventLevel)(Convert.ToInt32(minLevel));
        _logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .WriteTo.MSSqlServer(connectionString: conString, 
                                 tableName: "Logs", 
                                 autoCreateSqlTable: true)
            .CreateLogger();
    }
