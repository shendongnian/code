    public static class ConfigurationRootExtentions
        {
            public static List<T> GetListValue<T>(this IConfigurationRoot configurationRoot, string section)
            {
                var result = new List<T>();
                configurationRoot.GetSection(section).Bind(result);
                return result;
            }
        }
