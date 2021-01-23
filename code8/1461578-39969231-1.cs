    class RoleEnricher : ILogEventEnricher
    {
      public void Enrich(LogEvent logEvent, ILogEventPropertyFactory pf)
      {
        var role = // Get the role from your identity provider
        logEvent.AddOrUpdateProperty(pf.CreateProperty("Role", role));
      }
    }
