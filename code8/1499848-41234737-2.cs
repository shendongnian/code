    public class Program
    {
        public static void Main(string[] args)
        {
            string json = @"
            {
              ""thing_name1"": {
                ""property1"": 0,
                ""property2"": ""sure""
              },
              ""thing_name2"": {
                ""property1"": 34,
                ""property2"": ""absolutely""
              }
            }";
            var settings = new DataContractJsonSerializerSettings();
            settings.DataContractSurrogate = new MyDataContractSurrogate();
            settings.KnownTypes = new List<Type> { typeof(Dictionary<string, Dictionary<string, object>>) };
            settings.UseSimpleDictionaryFormat = true;
            List<Thing> things = Deserialize<List<Thing>>(json, settings);
            foreach (Thing thing in things)
            {
                Console.WriteLine("ThingName: " + thing.ThingName);
                Console.WriteLine("Property1: " + thing.Property1);
                Console.WriteLine("Property2: " + thing.Property2);
                Console.WriteLine();
            }
            json = Serialize(things, settings);
            Console.WriteLine(json);
        }
        public static T Deserialize<T>(string json, DataContractJsonSerializerSettings settings)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(typeof(T), settings);
                return (T)ser.ReadObject(ms);
            }
        }
        public static string Serialize(object obj, DataContractJsonSerializerSettings settings)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(obj.GetType(), settings);
                ser.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
