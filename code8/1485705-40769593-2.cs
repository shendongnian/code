    public class SystemTypeTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return typeof(Type).IsAssignableFrom(type);
        }
        public object ReadYaml(IParser parser, Type type)
        {
            var scalar = parser.Expect<Scalar>();
            return Type.GetType(scalar.Value);
        }
        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            var typeName = ((Type)value).AssemblyQualifiedName;
            emitter.Emit(new Scalar(typeName));
        }
    }
    // ....
    var serializer = new SerializerBuilder()
        .WithTypeConverter(new SystemTypeTypeConverter())
        .Build();
    var yaml = serializer.Serialize(new TypeContainer
    {
        Type = typeof(string),
    });
    var deserializer = new DeserializerBuilder()
        .WithTypeConverter(new SystemTypeTypeConverter())
        .Build();
    var result = deserializer.Deserialize<TypeContainer>(yaml);
    Assert.Equal(typeof(string), result.Type);
