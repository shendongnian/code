    public class Item
    {
        public object Value { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("o"),
            };
            var serializer = new DataContractJsonSerializer(typeof(Item), settings);
            var item = new Item { Value = DateTime.UtcNow };
            serializer.WriteObject(Console.OpenStandardOutput(), item);
        }
    }
