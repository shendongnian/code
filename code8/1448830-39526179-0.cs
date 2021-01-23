    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    
    public class Model
    {
        public int Count { get; set; }
        public string Text { get; set; }
        
    }
    
    internal sealed class FormatNumbersAsTextConverter : JsonConverter
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;
        public override bool CanConvert(Type type) => type == typeof(int);
        
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            int number = (int) value;
            writer.WriteValue(number.ToString(CultureInfo.InvariantCulture));
        }
        
        public override object ReadJson(
            JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Model { Count = 10, Text = "hello" };
            var settings = new JsonSerializerSettings
            { 
                Converters = { new FormatNumbersAsTextConverter() }
            };
            Console.WriteLine(JsonConvert.SerializeObject(model, settings));
        }
    }
