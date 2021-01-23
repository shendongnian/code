    class MyObject {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    var deserializer = new DeserializerBuilder()
         .WithNamingConvention(new CamelCaseNamingConvention())
         .Build();
    var result = deserializer.Deserialize<List<MyObject>>(File.OpenText("myfile.yml"));
