      using System;
      using System.Collections.Generic;
      using Newtonsoft.Json;
      using Newtonsoft.Json.Linq;
      
      namespace ConsoleApp1
      {
          public class RootObject
          {
              public string name { get; set; }
              public string tag { get; set; }
              public string description { get; set; }
              [JsonConverter(typeof(StringOrArrayToStringConveter<string>))]
              public string[] tags { get; set; }
          }
          
          class Program
          {
              static void Main(string[] args)
              {
                  var data1 = "{\"name\":\"test\", \"description\":\"test\",\"tags\":\"Maps\"}";
      
      
                  var deserialized1 = JsonConvert.DeserializeObject<RootObject>(data1);
      
      
                  var data2 = "{\"name\":\"test\", \"description\":\"test\",\"tags\":[\"Maps\", \"Maps2\"]}";
      
      
                  var deserialized2 = JsonConvert.DeserializeObject<RootObject>(data2);
      
              }
          }
      
          public class StringOrArrayToStringConveter<T> : JsonConverter
          {
              public override bool CanConvert(Type objectType)
              {
                  return true;
              }
      
              public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
              {
                  object returnValue = new Object();
                  if (reader.TokenType == JsonToken.StartArray)
                  {
                      returnValue = JToken.Load(reader).ToObject<T[]>();
                  }
                  else if (reader.TokenType == JsonToken.String)
                  {
                      T instance = (T)serializer.Deserialize(reader, typeof(T));
                      returnValue = new List<T>() { instance }.ToArray();
                  }
                  return returnValue;
              }
      
              public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
              {
                  throw new NotImplementedException();
              }
          }
      }
      
