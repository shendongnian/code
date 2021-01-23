    public class Example
    {
        [JsonConverter(typeof(MinDateTimeConverter))]
        public DateTime ValueOne { get; set; }
        [JsonConverter(typeof(MinDateTimeConverter))]
        public DateTime ValueTwo { get; set; }
    }
    public static void Main(string[] args)
    {
        Example data = new Example();
        data.ValueOne = DateTime.MinValue;
        data.ValueTwo = DateTime.Now;
        JsonSerializer serializer = new JsonSerializer();
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, data);
            Console.Write(writer.ToString());
        }
        Console.ReadKey();
    }
