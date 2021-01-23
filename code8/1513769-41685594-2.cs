    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
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
            List<string> dataList = jsonObject.Select(x => x.SelectData).ToList();
            dataList.ForEach(data =>
            {
                Console.WriteLine(data);
            });
            Console.ReadKey();
        }
    }
