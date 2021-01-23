    [DataContract]
    public sealed class CustomConfig
    {
       [DataMember]
        public int ConnectionTimeout {get;set;}
    }
   
    public sealed class MyConfig : ConfigurationSection
    {
        private CustomConfig _customCfg = new  CustomConfig(){ConnectionTimeout = this.ConnectionTimeout};
        [ConfigurationProperty("ConnectionTimeout", DefaultValue = 1000)]
        public int ConnectionTimeout
        {
            get { return (int)this["ConnectionTimeout"]; }
            set { _customCfg.ConnectionTimeout = value;this["ConnectionTimeout"] = value; }
        }
        ... // other values
    }
