    using System.Configuration;
    namespace ConfigSectionSample
    {
        internal class MyConfigurationSection : ConfigurationSection
        {
            public static MyConfigurationSection Current
            {
                get
                {
                    return (MyConfigurationSection)ConfigurationManager.GetSection("myConfig");
                }
            }
            [ConfigurationProperty("aNumber", IsRequired = true)]
            public int Number
            {
                get
                {
                    return (int)this["aNumber"];
                }
            }
            [ConfigurationProperty("aBoolean", IsRequired = true)]
            public bool Boolean
            {
                get
                {
                    return (bool)this["aBoolean"];
                }
            }
        }
    }
