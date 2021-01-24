    public interface INode
    {
        List<INodeInner> InnerNodes { get; set; }
    }
    public interface INodeInner : INode
    {
    }
    public class Node : INode
    {
        [JsonProperty(ItemConverterType = typeof(InterfaceToConcreteConverter<INodeInner, InnerNodeNodeType1>))]
        public List<INodeInner> InnerNodes { get; set; }
    }
    public class InnerNodeNodeType1 : INodeInner
    {
        [JsonProperty(ItemConverterType = typeof(InterfaceToConcreteConverter<INodeInner, InnerNodeNodeType2>))]
        public List<INodeInner> InnerNodes { get; set; }
        // some other properties
        public int Type1Property { get; set; }
    }
    public class InnerNodeNodeType2 : INodeInner
    {
        [JsonProperty(ItemConverterType = typeof(InterfaceToConcreteConverter<INodeInner, InnerNodeNodeType3>))]
        public List<INodeInner> InnerNodes { get; set; }
        // some even different properties
        public int Type2Property { get; set; }
    }
    public class InnerNodeNodeType3 : INodeInner
    {
        [JsonProperty(ItemConverterType = typeof(InterfaceToConcreteConverter<INodeInner, InnerNodeNodeType3>))]
        public List<INodeInner> InnerNodes { get; set; }
        // some even different properties
        public int Type3Property { get; set; }
    }
    public class InterfaceToConcreteConverter<TInterface, TConcrete> : JsonConverter where TConcrete : TInterface
    {
        public InterfaceToConcreteConverter()
        {
            // TConcrete should be a subtype of an abstract type, or an implementation of an interface.  If they
            // are identical an infinite recursion could result, so throw an exception.
            if (typeof(TInterface) == typeof(TConcrete))
                throw new InvalidOperationException(string.Format("typeof({0}) == typeof({1})", typeof(TInterface), typeof(TConcrete)));
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TInterface);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(TConcrete));
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
