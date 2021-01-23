    public interface ICustomIDList : IList<CustomID> {}
    public class CustomIDListConverter : IYamlTypeConverter { /* ... */ }
    var deserializer = new DeserializerBuilder()
       .WithTypeConverter(new CustomIDListConverter())
       .Build();
