    private static dynamic DynamicSettings(Settings settings)
    {
      var settingsDyn = settings.ToDynamic();
      if (settingsDyn == null)
        return settings;
      settingsDyn.guid = Guid.NewGuid();
      return settingsDyn;
    }
