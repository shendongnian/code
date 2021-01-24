    [TypeConverter(typeof(X509CertificateConverter))]
    public class X509CertificateConfigurationElement : ConfigurationElement
    {
        private ConfigurationPropertyCollection properties;
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (this.properties == null)
                {
                    this.properties = new ConfigurationPropertyCollection
                    {
                        new ConfigurationProperty("findValue", typeof(string), string.Empty, null, new StringValidator(0, 2147483647, null), ConfigurationPropertyOptions.None),
                        new ConfigurationProperty("storeLocation", typeof(StoreLocation), StoreLocation.CurrentUser, null, null, ConfigurationPropertyOptions.None),
                        new ConfigurationProperty("storeName", typeof(StoreName), StoreName.My, null, null, ConfigurationPropertyOptions.None),
                        new ConfigurationProperty("x509FindType", typeof(X509FindType), X509FindType.FindBySubjectDistinguishedName, null, null, ConfigurationPropertyOptions.None)
                    };
                }
                return this.properties;
            }
        }
        [ConfigurationProperty("findValue", DefaultValue = ""), StringValidator(MinLength = 0)]
        public string FindValue
        {
            get
            {
                return (string)base["findValue"];
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = string.Empty;
                }
                base["findValue"] = value;
            }
        }
        [ConfigurationProperty("storeLocation", DefaultValue = StoreLocation.CurrentUser)]
        public StoreLocation StoreLocation
        {
            get
            {
                return (StoreLocation)base["storeLocation"];
            }
            set
            {
                base["storeLocation"] = value;
            }
        }
        [ConfigurationProperty("storeName", DefaultValue = StoreName.My)]
        public StoreName StoreName
        {
            get
            {
                return (StoreName)base["storeName"];
            }
            set
            {
                base["storeName"] = value;
            }
        }
        [ConfigurationProperty("x509FindType", DefaultValue = X509FindType.FindBySubjectDistinguishedName)]
        public X509FindType X509FindType
        {
            get
            {
                return (X509FindType)base["x509FindType"];
            }
            set
            {
                base["x509FindType"] = value;
            }
        }
    }
