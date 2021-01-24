        public class BDKElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("value", IsRequired = false)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
    
