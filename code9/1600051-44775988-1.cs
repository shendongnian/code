    using System.Net;
    using System.IO;
    using Newtonsoft.Json;
	private static void start_get()
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.coinmarketcap.com/v1/ticker/"));
    
        WebReq.Method = "GET";
    
        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
    
        Console.WriteLine(WebResp.StatusCode);
        Console.WriteLine(WebResp.Server);
    
        string jsonString;
        using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
        {
           StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
           jsonString = reader.ReadToEnd();
        }
        
        List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
        
        Console.WriteLine(items.Count);     //returns 921, the number of items on that page
    }
