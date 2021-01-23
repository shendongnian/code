    public FolderPreferences Read(string configurationFile)
    {
        using (var input = File.OpenText(configurationFile))
        {
            var deserializerBuilder = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention());
            var deserializer = deserializerBuilder.Build();
            var result = deserializer.Deserialize<FolderPreferences>(input);
            return result;
        }
    }
