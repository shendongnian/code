    public static class ConfigurationHelper
    {
        public static T GetObjectFromConfigSection<T>(
            this IConfigurationRoot configurationRoot,
            string configSection) where T : new()
        {
            var result = new T();
            foreach (var propInfo in typeof(T).GetProperties())
            {
                var propertyType = propInfo.PropertyType;
                if (propInfo?.CanWrite ?? false)
                {
                    var value = Convert.ChangeType(configurationRoot.GetValue<string>($"{configSection}:{propInfo.Name}"), propInfo.PropertyType);
                    propInfo.SetValue(result, value, null);
                }
            }
            return result;
        }
    }
