    public static async Task Main(string[] args)
    {
        var json = File.ReadAllText("json-schema-sample.json");
    
        var schema = await JsonSchema4.FromJsonAsync(json);
    
        var csharpSetting = new CSharpGeneratorSettings {Namespace = "Generated.Json", ClassStyle = CSharpClassStyle.Poco};
        var generator = new CSharpGenerator(schema, csharpSetting);
        var file = generator.GenerateFile("Root");
    
        using (var sw = File.CreateText("Generated.cs"))
        {
            sw.Write(file);
        }
    }
