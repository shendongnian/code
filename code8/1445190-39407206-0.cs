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
            var serializer = new JsonSerializer();
        
            // Serialize anonymous object.
            using (var ms     = new MemoryStream())
            using (var writer = new BsonWriter(ms))
            {
                serializer.Serialize(writer, my);
                data = ms.ToArray();
            }
            // Deserialize anonymous object.
            using (var ms     = new MemoryStream(data))
            using (var reader = new BsonReader(ms))
            {
                dynamic obj = serializer.Deserialize(reader);
                Console.WriteLine(obj.Test);  // Prints "a1"
                Console.WriteLine(obj.Value); // Prints 12345
            }
        }
    } 
