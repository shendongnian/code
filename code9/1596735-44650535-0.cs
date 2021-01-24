    public SerilogHelper(string conString = null, int minLevel = -1)
    {
        if (minLevel == -1)
          minLevel = SSOSettingsFileManager.SSOSettingsFileReader.ReadString(
          "LCC.Common", "serilog.level");
        if (conString == null)
          conString = SSOSettingsFileManager.SSOSettingsFileReader.ReadString(
          "LCC.Common", "serilog.connectionstring");
        var levelSwitch = new LoggingLevelSwitch();
        levelSwitch.MinimumLevel = (Serilog.Events.LogEventLevel)(Convert.ToInt32(minLevel));
        _logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .WriteTo.MSSqlServer(connectionString: conString, 
                                 tableName: "Logs", 
                                 autoCreateSqlTable: true)
            .CreateLogger();
    }
....
    SerilogHelper myInstance = new SerilogHelper();
