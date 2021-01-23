    // Requires NuGet package Microsoft.Extensions.Configuration.Json
    
    using Microsoft.Extensions.Configuration;
    using System.IO;
    
    namespace RutarBackgroundServices.AppsettingsJson
    {
        public static class AppSettingsJson
        {
            public static string ApplicationExeDirectory()
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appRoot = Path.GetDirectoryName(location);
    
                return appRoot;
            }
    
            public static IConfigurationRoot GetAppSettings()
            {
                string applicationExeDirectory = ApplicationExeDirectory();
    
                var builder = new ConfigurationBuilder()
                .SetBasePath(applicationExeDirectory)
                .AddJsonFile("appsettings.json");
    
                return builder.Build();
            }
    
        }
    }
