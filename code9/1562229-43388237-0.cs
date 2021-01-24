    private static ConfigurationProperty CreateConfigurationPropertyFromAttributes(PropertyInfo propertyInformation)
    {
      ConfigurationProperty configurationProperty = (ConfigurationProperty) null;
      if (Attribute.GetCustomAttribute((MemberInfo) propertyInformation, typeof (ConfigurationPropertyAttribute)) is ConfigurationPropertyAttribute)
        configurationProperty = new ConfigurationProperty(propertyInformation);
      if (configurationProperty != null && typeof (ConfigurationElement).IsAssignableFrom(configurationProperty.Type))
      {
        ConfigurationPropertyCollection result = (ConfigurationPropertyCollection) null;
        ConfigurationElement.PropertiesFromType(configurationProperty.Type, out result);
      }
      return configurationProperty;
    }
