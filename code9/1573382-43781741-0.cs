    We cant add to ConfigurationManager.ConnectionStrings using ConfigurationManager.ConnectionStrings.Add(connectionStringSettings) -- This fails.
    But we can add to the configuration section and refresh the ConfigurationManager.
    
    public static void AddConnectionStringSettings(
           System.Configuration.Configuration config,
           System.Configuration.ConnectionStringSettings conStringSettings)
    
    {   
       ConnectionStringsSection connectionStringsSection = config.ConnectionStrings; 
      connectionStringsSection.ConnectionStrings.Add(conStringSettings);  
      config.Save(ConfigurationSaveMode.Minimal); 
      ConfigurationManager.RefreshSection("connectionStrings"); 
    }
