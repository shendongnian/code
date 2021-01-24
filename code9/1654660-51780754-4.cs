    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    
    namespace Custom
    {
        static class ConfigurationManager
        {
            public static IConfiguration AppSetting { get; }
            static ConfigurationManager()
            {
                AppSetting = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("YouAppSettingFile.json")
                        .Build();
            }
        }
    }
