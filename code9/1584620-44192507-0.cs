    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Diagnostics;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string result = "{\"TOTAL\":177,\"PRODUCTS\":[{\"CODE\":\"T55-2A\",\"PRICE\":59.9500,\"NAME\":\"Arrive In Style\"},{\"CODE\":\"F1-231\",\"PRICE\":49.9500}]}";
    
                var deserialized = JsonConvert.DeserializeObject<Result>(result);
    
                Debug.Assert(deserialized.Books.Count == 2);
            }
        }
    
        public class Result
        {
            [JsonProperty("TOTAL")]
            public int Total { get; set; }
    
            [JsonProperty("PRODUCTS")]
            public List<Book> Books { get; set; }
        }
    
        public class Book
        {
            [JsonProperty("CODE")]
            public string Code { get; set; }
    
            [JsonProperty("PRICE")]
            public float Price { get; set; }
    
            [JsonProperty("NAME")]
            public string Name { get; set; }
        }
    }
