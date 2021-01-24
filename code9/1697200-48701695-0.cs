    using System;
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;
    
    namespace ConsoleApp2
    {
        public class Program
        {
            public static void Main()
            {
                string json =
                    "{ \"status\": \"success\", \"data\": { \"resultType\": \"vector\", \"result\": [ { \"metric\": { \"__name__\": \"node_cpu\", \"cpu\": \"cpu0\", \"instance\": \"localhost:9100\", \"job\": \"node\", \"mode\": \"guest\" }, \"value\": [ 1518159211.958, \"0\" ] }, { \"metric\": { \"__name__\": \"node_cpu\", \"cpu\": \"cpu0\", \"instance\": \"localhost:9100\", \"job\": \"node\", \"mode\": \"guest_nice\" }, \"value\": [ 1518159211.958, \"0\" ] } ] } }";
                var data = VerificationResponse.FromJson(json);
                Console.WriteLine(data);
            }
        }
    
    
        public partial class VerificationResponse
        {
            [JsonProperty("status")]
            public string Status { get; set; }
    
            [JsonProperty("data")]
            public Data Data { get; set; }
        }
    
        public partial class Data
        {
            [JsonProperty("resultType")]
            public string ResultType { get; set; }
    
            [JsonProperty("result")]
            public List<Result> Result { get; set; }
        }
    
        public partial class Result
        {
            [JsonProperty("metric")]
            public Metric Metric { get; set; }
    
            [JsonProperty("value")]
            public List<Value> Value { get; set; }
        }
    
        public partial class Metric
        {
            [JsonProperty("__name__")]
            public string Name { get; set; }
    
            [JsonProperty("cpu")]
            public string Cpu { get; set; }
    
            [JsonProperty("instance")]
            public string Instance { get; set; }
    
            [JsonProperty("job")]
            public string Job { get; set; }
    
            [JsonProperty("mode")]
            public string Mode { get; set; }
        }
    
        public partial struct Value
        {
            public double? Double;
            public string String;
        }
    
        public partial class VerificationResponse
        {
            public static VerificationResponse FromJson(string json) => JsonConvert.DeserializeObject<VerificationResponse>(
                json, Converter.Settings);
        }
    
        public partial struct Value
        {
            public Value(JsonReader reader, JsonSerializer serializer)
            {
                Double = null;
                String = null;
    
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                    case JsonToken.Float:
                        Double = serializer.Deserialize<double>(reader);
                        return;
                    case JsonToken.String:
                    case JsonToken.Date:
                        String = serializer.Deserialize<string>(reader);
                        return;
                }
                throw new Exception("Cannot convert Value");
            }
    
            public void WriteJson(JsonWriter writer, JsonSerializer serializer)
            {
                if (Double != null)
                {
                    serializer.Serialize(writer, Double);
                    return;
                }
                if (String != null)
                {
                    serializer.Serialize(writer, String);
                    return;
                }
                throw new Exception("Union must not be null");
            }
        }
    
        public static class Serialize
        {
            public static string ToJson(this VerificationResponse self) => JsonConvert.SerializeObject(self,
                Converter.Settings);
        }
    
        public class Converter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Value);
    
            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (t == typeof(Value))
                    return new Value(reader, serializer);
                throw new Exception("Unknown type");
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var t = value.GetType();
                if (t == typeof(Value))
                {
                    ((Value) value).WriteJson(writer, serializer);
                    return;
                }
                throw new Exception("Unknown type");
            }
    
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {new Converter()},
            };
        }
    }
