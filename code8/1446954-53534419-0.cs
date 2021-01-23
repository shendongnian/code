    static TimeZoneInfo getCorrectTimeZone()
    {
      return TimeZoneInfo.CreateCustomTimeZone("Time zone to workaround a bug", TimeZoneInfo.Local.BaseUtcOffset, "Time zone to workaround a bug", "Time zone to workaround a bug");
    }
    
    static ExchangeService getExchangeService()
    {
      var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2, getCorrectTimeZone());
      return service;
    }
     
