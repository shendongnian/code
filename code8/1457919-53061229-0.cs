    public class PackSettingReader
    {
        public PackSettingReader(string settingKeyPrefix = null)
        {
            SettingKeyPrefix = settingKeyPrefix;
        }
        public PackSettingReader(Type settingKeyTypePrefix)
            : this(settingKeyTypePrefix.FullName)
        {
        }
        public string SettingKeyPrefix { get; }
        public string Get(string settingKey, string defaultValue)
        {
            return Get(settingKey) ?? defaultValue;
        }
        public TValue Get<TValue>(string settingKey, TValue defaultValueOnNotFound = default(TValue),
            bool throwExceptionOnNotFound = false)
        {
            try
            {
                var valueString = Get(settingKey);
                if (valueString != null)
                    if (typeof(TValue) == typeof(Guid))
                        return (TValue) Convert.ChangeType(Guid.Parse(valueString), typeof(Guid));
                    else if (typeof(TValue) == typeof(Type))
                        return (TValue) (object) Type.GetType(valueString, throwExceptionOnNotFound);
                    else if (typeof(TValue).IsEnum)
                        return (TValue) Enum.Parse(typeof(TValue), valueString);
                    else if (typeof(TValue) == typeof(int[]))
                        return (TValue) (object) valueString.Split(',').Select(s => int.Parse(s)).ToArray();
                    else if (typeof(TValue) == typeof(TimeSpan))
                        return (TValue) (object) TimeSpan.Parse(valueString);
                    else
                        return (TValue) Convert.ChangeType(valueString, typeof(TValue));
                if (throwExceptionOnNotFound)
                    throw new InvalidOperationException("Setting key '" + settingKey + "' value not found!");
                return defaultValueOnNotFound;
            }
            catch (Exception)
            {
                if (throwExceptionOnNotFound)
                    throw;
                return defaultValueOnNotFound;
            }
        }
        private string Get(string settingKey)
        {
            var settingProvider =
                ServiceLocator.ResolveOnCurrentInstance<ISettingProvider, ConfigurationSettingProvider>();
            return settingProvider?[SettingKeyPrefix, settingKey];
        }
        public string GetFullKey(string settingKey)
        {
            if (!string.IsNullOrEmpty(SettingKeyPrefix))
                settingKey = SettingKeyPrefix + '.' + settingKey;
            return settingKey;
        }
    }
