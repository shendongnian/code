    public class Service1 : IService1   
    {   
        public void DoWork();   
        public static void Configure(ServiceConfiguration config)   
        {   
              config.LoadFromConfiguration(ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = @"c:\sharedConfig\MyConfig.config" }, ConfigurationUserLevel.None));   
        }   
    }  
