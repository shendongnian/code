    public static string GetConfigurationValue()
    {
        if(ConfigurationManager.AppSettings["dbpath"]!=null)
          return ConfigurationManager.AppSettings["dbpath"];
        else 
          return string.Empty;
    }
