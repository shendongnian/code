    using System;
    using System.Collections.Generic;
    using RestSharp;
    
    namespace Test
    {
        public class ItemDetails
        {
            public List<Itemschema> items { get; set; }
        }
        public class Itemschema
        {
            public int id { get; set; }
            public string sku { get; set; }
            public string name { get; set; }
            public int attribute_set_id { get; set; }
            public int price { get; set; }
            public int status { get; set; }
            public int visibility { get; set; }
            public string type_id { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public int weight { get; set; }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                IRestClient client = new RestClient("http://www.mocky.io/v2/595616d92900003d02cd7191");
                IRestRequest request = new RestRequest(Method.GET);
                request.RequestFormat = DataFormat.Json;
    
                IRestResponse<ItemDetails> response = client.Execute<ItemDetails>(request);
                var Items = SimpleJson.DeserializeObject<ItemDetails>(response.Content);
                Console.WriteLine(Items.items.Count);
                Console.ReadLine();
            }
        }
    }
