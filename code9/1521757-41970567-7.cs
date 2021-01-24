        var settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
            Converters = { new TypeConverter() } 
        };
        Console.WriteLine(JsonConvert.SerializeObject(new Foo(), settings));
