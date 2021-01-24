    public class Test
    {
         public string message { get; set; }
    }
    
    string privet = "Привет";
    Test.message = privet;
    string json = JsonConvert.SerializeObject(Test, Formatting.Indented);
    
    byte[] sbBites = Encoding.UTF8.GetBytes(json);
    Uri url = new Uri("https://example.net");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "POST";
    request.ContentLength = sbBites.Length;
    request.ContentType = "application/json";
    
    using (Stream requestStream = request.GetRequestStream())
    {
         requestStream.Write(sbBites, 0, sbBites.Length);
    }
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
