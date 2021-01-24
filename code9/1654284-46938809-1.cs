    public static class CustomJsonConvert
    {
        // You may want to cache the contract resolver for best performance, see
        // https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static readonly JsonSerializerSettings jsonSettings;
        static CustomJsonConvert()
        {
            jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new NoTypeNameHandlingContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        // These are the settings used by CamelCasePropertyNamesContractResolver by default.
                        // Change them if this is not what you want.
                        OverrideSpecifiedNames = true,
                        ProcessDictionaryKeys = true,
                    },
                },
                EqualityComparer = (IEqualityComparer)null,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
                Converters = { new StringEnumConverter { CamelCaseText = true } },
            };
        }
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, jsonSettings);
        }
    }
