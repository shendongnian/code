    public class NullToEmptyStringResolver : DefaultContractResolver
    {
        public NullToEmptyStringResolver() : base()
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true,
                OverrideSpecifiedNames = true
            };
        }
    
        ...
    }
