    public class KnownTypesBinder : ISerializationBinder
    {
        public IList<Type> KnownTypes { get; set; }
    
        public Type BindToType(string assemblyName, string typeName)
        {
            return KnownTypes.SingleOrDefault(t => t.Name == typeName);
        }
    
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
    
    public class Car
    {
        public string Maker { get; set; }
        public string Model { get; set; }
    }
	
	KnownTypesBinder knownTypesBinder = new KnownTypesBinder
    {
        KnownTypes = new List<Type> { typeof(Car) }
    };
    
    Car car = new Car
    {
        Maker = "Ford",
        Model = "Explorer"
    };
    
    string json = JsonConvert.SerializeObject(car, Formatting.Indented, new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Objects,
        SerializationBinder = knownTypesBinder
    });
    
    Console.WriteLine(json);
    // {
    //   "$type": "Car",
    //   "Maker": "Ford",
    //   "Model": "Explorer"
    // }
    
    object newValue = JsonConvert.DeserializeObject(json, new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Objects,
        SerializationBinder = knownTypesBinder
    });
    
    Console.WriteLine(newValue.GetType().Name);
    // Car
