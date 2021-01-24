    MSSqlServerConfigurationSection serviceConfigSection =
        ConfigurationManager.GetSection("MSSqlServerSettingsSection") as MSSqlServerConfigurationSection;
    
    // If we have additional columns from config, load them as well
    if (serviceConfigSection != null && serviceConfigSection.Columns.Count > 0)
    {
        if (columnOptions == null)
        {
            columnOptions = new ColumnOptions();
        }
        GenerateDataColumnsFromConfig(serviceConfigSection, columnOptions);
    }
