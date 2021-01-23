    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public DeserializeObjectClass()
    {
        static void Main(string[] args)
        {
            // Code for getting json object. 
            string jsonObject = "{'panels': {'address": 'random', 'id': '0'}}";
            panels myPanel = JsonConvert.DeserializeObject<TEVISResult>(jsonObject);
            Console.WriteLine(panel.adress);
        }
    }
    // And now for you panel object in c#
    public class panels
    {
         public panels()
         {
         }
         public string address { get; set; }
         public string id { get; set; }
    }
