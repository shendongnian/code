    public class MyJsonObject
    {
        public string FlightCombination { get; set; }
        public string SelectData { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = @"[
              {
                ""FlightCombination"": ""{ }"",
                ""SelectData"": ""RwoAAB +LCAAAAAAABADNAA""
              },
              {
                ""FlightCombination"": ""{ }"",
                ""SelectData"": ""0QoAAB+LCAAAAAAABADA==""
              },
              {
                ""FlightCombination"": ""{ }"",
                ""SelectData"": ""WwoAAB +LCAAAAAAABAD""
              }
            ]";
            var jsonObject = JsonConvert.DeserializeObject<List<MyJsonObject>>(jsonString);
            jsonObject.ForEach(x =>
            {
                Console.WriteLine(x.SelectData);
            });
            Console.ReadKey();
        }
    }
