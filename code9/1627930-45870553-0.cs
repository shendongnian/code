    public class SpecialConfig : ConfigSection
    {
        [ConfigurationProperty("UnicornSettings")]
        public UnicornSettingsElement UnicornSettings
        {
            get
            {
                return (UnicornSettingsElement)this["UnicornSettings"];
            }
            set
            {
                this["UnicornSettings"] = value;
            }
        }
    }
    
    public class UnicornSettingsElement : ConfigElement
    {
        public UnicornSettingsElement(ConfigElement parent) : base(parent)
        {
    
        }
        [ConfigurationProperty("HornSize", IsRequired = true)]
        public String HornSize
        {
            get
            {
                return (String)this["HornSize"];
            }
            set
            {
                this["HornSize"] = value;
            }
        }
        [ConfigurationProperty("HoofColor", IsRequired = true)]
        public String HoofColor
        {
            get
            {
                return (String)this["HoofColor"];
            }
            set
            {
                this["HoofColor"] = value;
            }
        }
    }
        
