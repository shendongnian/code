    using System;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    
    namespace GetRequest
    {
        class PARSE
        {
            public int userID { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
    
            public override string ToString()
            {
                return string.Format("UserID: {0} \nid: {1} \ntitle: {2} \nbody {3}", userID, id, title, body);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Create the web request  
                HttpWebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/posts") as HttpWebRequest;
    
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    {
                        string myString = reader.ReadToEnd();
                        System.IO.File.WriteAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\WriteText.json", myString);
                    }
                    // JSON deserialize from a file
                    String JSONstring = File.ReadAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\WriteText.json");
                    List<PARSE> pList = JsonConvert.DeserializeObject<List<PARSE>>(JSONstring);           
                    foreach(PARSE p in pList) {
                        Console.WriteLine(p);
                        Console.ReadLine();
                    }
                }
            }
        }
    }
