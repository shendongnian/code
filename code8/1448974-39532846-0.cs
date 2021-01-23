      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      config.ConnectionStrings.ConnectionStrings.Remove("string.name");
      config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("string.name", "new connection string"));
      config.Save(ConfigurationSaveMode.Modified);
      ConfigurationManager.RefreshSection("connectionStrings");
