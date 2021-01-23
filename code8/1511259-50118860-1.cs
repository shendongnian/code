    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    
    public static class ConfigurationExtensions
    {
        public static IConfigurationSection GetSectionChecked(this IConfiguration config, string sectionName)
        {
            var section = config.GetSection(sectionName);
            CheckSection(section);
            return section;
        }
    
        public static IServiceCollection ConfigureSection<TOptions>(this IServiceCollection services, IConfiguration config, string sectionName = null) 
            where TOptions : class
        {
            string typeName = sectionName ?? typeof(TOptions).Name;
            IConfigurationSection section = config.GetSectionChecked(typeName);
            return services.Configure<TOptions>(section);
        }
    
        public static IServiceCollection ConfigureSection<TOptions>(this IServiceCollection services, IConfigurationSection section, string sectionName = null)
            where TOptions : class
        {
            CheckSection(section);
            return services.ConfigureSection<TOptions>((IConfiguration)section, sectionName);
        }
    
        private static void CheckSection(IConfigurationSection section)
        {
            if (!section.Exists())
                throw new ArgumentException($"Configuration section '{section.Path}' doesn't exist.");
        }
    }
