    public class Program
    {
        public static void Main(string[] args)
        {
            string j = @"
            {
              ""products"": [
                {
                  ""descriptions"": {
                    ""brand"": [ ""abc"" ]
                  }
                },
                {
                  ""descriptions"": {
                    ""brand"": [ ""xyz"" ]
                  }
                }
              ]
            }";
            JObject o = JObject.Parse(j);
            JArray a = (JArray)o["products"];
            string brandString = "descriptions.brand[0]";
            var products = a.Select(p => new Product
            {
                Brand = (string)p.SelectToken(brandString)
            });
            foreach (Product p in products)
            {
                Console.WriteLine(p.Brand);
            }
        }
    }
    class Product
    {
        public string Brand { get; set; }
    }
