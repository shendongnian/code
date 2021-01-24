    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Response
    {
        public int Status { get; set; }
        public Dictionary<string, Hotel> Data { get; set; }
    }
    
    public class Hotel
    {
        [JsonProperty("total_price")]
        public Dictionary<string, Room> TotalPrice { get; set; }
    }
    
    public class Room
    {
        public int Available { get; set; }
        public decimal? Price { get; set; }
        public bool Availability { get; set; }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("test.json");
            var response = JsonConvert.DeserializeObject<Response>(text);
            foreach (var pair in response.Data)
            {
                Console.WriteLine($"Key: {pair.Key}");
                foreach (var nestedPair in pair.Value.TotalPrice)
                {
                    var room = nestedPair.Value;
                    Console.WriteLine($"  {nestedPair.Key}: {room.Available}/{room.Price}/{room.Availability}");
                }
            }
        }
    }
