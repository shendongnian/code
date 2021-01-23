    using System;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    public class Program
    {
        static void Main()
        {
            var my = new
            {
                Test = "a1",
                Value = 12345
            };
            byte[] data;
            // Serialize anonymous object.
            var serializer = new JsonSerializer();
            using (var ms = new MemoryStream())
            using (var writer = new BsonWriter(ms))
            {
                serializer.Serialize(writer, my);
                data = ms.ToArray();
            }
            // Deserialize anonymous object.
            // Use a dummy exemplar object to allow a template
            //method to access the underlying type.
            var deserialized = new
            {
                Test = "",
                Value = 0
            };
            deserialized = Deserialize(deserialized, data);
            Console.WriteLine(deserialized.Test);
            Console.WriteLine(deserialized.Value);
        }
        public static T Deserialize<T>(T typeHolder, byte[] data)
        {
            var serializer = new JsonSerializer();
            using (var ms     = new MemoryStream(data))
            using (var reader = new BsonReader(ms))
            {
                return serializer.Deserialize<T>(reader);
            }
        }
    }
