    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace DesrializeJson1ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonstring = "\"[{\\\"ProductId\\\":1,\\\"ProductName\\\":\\\"abuka\\\",\\\"Rate\\\":6.00,\\\"Quantity\\\":10.000},{\\\"ProductId\\\":2,\\\"ProductName\\\":\\\"abuka\\\",\\\"Rate\\\":6.00,\\\"Quantity\\\":10.000},{\\\"ProductId\\\":3,\\\"ProductName\\\":\\\"abuka\\\",\\\"Rate\\\":6.00,\\\"Quantity\\\":10.000}]\"";
                var serializer = new JavaScriptSerializer();
                var jsonObject = serializer.Deserialize<string>(jsonstring);
                List<Product> lstProducts = serializer.Deserialize<List<Product>>(jsonObject);
                foreach(var item in lstProducts)
                {
                    Console.WriteLine("ProductId :" + item.ProductId);
                    Console.WriteLine("ProductName :" + item.ProductName);
                    Console.WriteLine("Rate :" + item.Rate);
                    Console.WriteLine("Quantity :" + item.Quantity);
                    Console.WriteLine("--------------------------");
                }
                Console.Read();
            }
        }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public double Rate { get; set; }
            public double Quantity { get; set; }
        }
    
    }
