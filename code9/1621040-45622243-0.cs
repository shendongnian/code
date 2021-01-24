    public class CustomJsonSerializer : SerializationDefinition
    {
        public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings)
        {
            var xmlSerializerDefinition = new XmlSerializer();
            var xmlSerializerFactory = xmlSerializerDefinition.Configure(settings);
    
            var jsonSerializerDefinition = new JsonSerializer();
            var jsonSerializerFactory = jsonSerializerDefinition.Configure(settings);
            return mapper => new DecoratorSerializer(xmlSerializerFactory(mapper), jsonSerializerFactory(mapper));
        }
    }
