    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var client = new RestClient("https://www.cryptocompare.com/api");
    
                var response = client.Execute<DataContainer>(new RestRequest("/data/coinlist"));
    
                var data = response.Data;        }
        }
    
        public class DataContainer
        {
            public string Message { get; set; }
            public Dictionary<string, DataItem> Data { get; set; }
        }
    
        public class DataItem
        {
            public string Id { get; set; }
            public string Url { get; set; }
            public string ImageUrl { get; set; }
            public string Name { get; set; }
        
        }
    }
