    public class BasicAuthenticationSection : ConfigurationSection
    {
        public static string SectionName = "basicAuthentication";
        [ConfigurationProperty("enabled", DefaultValue = false)]
        public bool Enabled
        {
            get { return (bool)base["enabled"]; }
            set { base["enabled"] = value; }
        }       
        [ConfigurationProperty("requireSSL", DefaultValue = true)]
        public bool RequireSSL
        {
            get { return (bool)base["requireSSL"]; }
            set { base["requireSSL"] = value; }
        }
    }
  
