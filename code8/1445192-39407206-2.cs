    using System;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    public class Program
    {
        static void Main()
        {
            var data = serializeAnonymousObject();
            deserializeAnonymousObject(data);
        }
        static byte[] serializeAnonymousObject()
        {
            // This is in a separate method to demonstrate that you can
            // serialize in one place and deserialize in another.
            var my = new
            {
                Test  = "a1",
                Value = 12345
            };
            return Serialize(my);
        }
        static void deserializeAnonymousObject(byte[] data)
        {
            // This is in a separate method to demonstrate that you can
            // serialize in one place and deserialize in another.
            var deserialized = new  // Dummy type for casting.
            {
                Test  = "",
                Value = 0
            };
            deserialized = Deserialize(deserialized, data);
            Console.WriteLine(deserialized.Test);
            Console.WriteLine(deserialized.Value);
        }
        public static byte[] Serialize(object obj)
        {
            using (var ms     = new MemoryStream())
            using (var writer = new BsonWriter(ms))
            {
                new JsonSerializer().Serialize(writer, obj);
                return ms.ToArray();
            }
        }
        public static T Deserialize<T>(T typeHolder, byte[] data)
        {
            using (var ms     = new MemoryStream(data))
            using (var reader = new BsonReader(ms))
            {
                return new JsonSerializer().Deserialize<T>(reader);
            }
        }
    }
