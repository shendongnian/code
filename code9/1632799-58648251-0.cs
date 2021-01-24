using Microsoft.Extensions.Configuration;
namespace your-name
{
    static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath("C:/Users/Name/Documents/AnotherSettings/") //instead of .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
Hope this helps.
