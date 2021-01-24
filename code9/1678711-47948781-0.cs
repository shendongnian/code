    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    namespace StackOverFlow
    {
        class Program
        {
            static void Main(string[] args)
            {
                var request = System.Net.WebRequest.Create("https://esi.tech.ccp.is/latest/markets/10000002/history/?datasource=tranquility&type_id=42") as System.Net.HttpWebRequest;
                request.Method = "GET";
                request.ContentLength = 0;
                using (var response = request.GetResponse() as System.Net.HttpWebResponse)
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception(response.StatusCode + "\t" + response.StatusDescription);
                    }
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<MarketHistory>));
                    var result = jsonSerializer.ReadObject(response.GetResponseStream()) as List<MarketHistory>;
                }
                Console.ReadLine();
            }
        }
        public class MarketHistory
        {
            public string date { get; set; }
            public string order_count { get; set; }
            public string volume { get; set; }
            public string highest { get; set; }
            public string average { get; set; }
            public string lowest { get; set; }
        }
    }
