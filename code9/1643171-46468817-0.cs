    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddJsonFileWithPrefix(this IConfigurationBuilder configurationBuilder, string fileName, string prefix) 
        {
            var config = new ConfigurationBuilder()
                // you may need to set up base path again here
                // .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName).Build();
            
            var result = new List<KeyValuePair<string, string>>();
            foreach(var pair in config.AsEnumerable())
            {
                result.Add(new KeyValuePair<string, string>($"{prefix}:{pair.Key}", pair.Value));
            }
            return configurationBuilder.AddInMemoryCollection(result);
        }
    } 
