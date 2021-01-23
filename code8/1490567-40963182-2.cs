    public class Program
    {
        public static void Main(string[] args)
        {
            string json = @"{""keys"":[""foo"",""fizz""],""values"":[""bar"",""bang""]}";
            CustomConverter converter = new CustomConverter();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(converter);
            // Here we are reading a JSON object containing two arrays into a dictionary
            // (custom read) and then writing out the dictionary JSON (standard write)
            Console.WriteLine("--- Situation 1 (custom read, standard write) ---");
            converter.Behavior = ConverterBehavior.CustomReadStandardWrite;
            json = DeserializeThenSerialize(json, settings);
            // Here we are reading a simple JSON object into a dictionary (standard read)
            // and then writing out a new JSON object containing arrays (custom write)
            Console.WriteLine("--- Situation 2 (standard read, custom write) ---");
            converter.Behavior = ConverterBehavior.StandardReadCustomWrite;
            json = DeserializeThenSerialize(json, settings);
        }
        private static string DeserializeThenSerialize(string json, JsonSerializerSettings settings)
        {
            Console.WriteLine("Deserializing...");
            Console.WriteLine(json);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json, settings);
            Console.WriteLine("Serializing...");
            json = JsonConvert.SerializeObject(dict, settings);
            Console.WriteLine(json);
            Console.WriteLine();
            return json;
        }
    }
    enum ConverterBehavior { CustomReadStandardWrite, StandardReadCustomWrite }
    class CustomConverter : JsonConverter
    {
        public ConverterBehavior Behavior { get; set; }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary<string, string>).IsAssignableFrom(objectType);
        }
        public override bool CanRead
        {
            get { return Behavior == ConverterBehavior.CustomReadStandardWrite; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Console.WriteLine("ReadJson was called");
            // Converts a JSON object containing a keys array and a values array
            // into a Dictionary<string, string>
            JObject jo = JObject.Load(reader);
            return jo["keys"].Zip(jo["values"], (k, v) => new JProperty((string)k, v))
                             .ToDictionary(jp => jp.Name, jp => (string)jp.Value);
        }
        public override bool CanWrite
        {
            get { return Behavior == ConverterBehavior.StandardReadCustomWrite; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Console.WriteLine("WriteJson was called");
            // Converts a dictionary to a JSON object containing 
            // a keys array and a values array from the dictionary
            var dict = (Dictionary<string, string>)value;
            JObject jo = new JObject(new JProperty("keys", new JArray(dict.Keys)),
                                     new JProperty("values", new JArray(dict.Values)));
            jo.WriteTo(writer);
        }
    }
