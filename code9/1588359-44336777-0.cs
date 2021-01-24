    string url = @"http://restcountries.eu/rest/v1";
    DataContractJsonSerializer serializer = 
        new DataContractJsonSerializer(typeof(IEnumerable<Class1>));
    WebClient syncClient = new WebClient();
    string content = syncClient.DownloadString(url);
    
    using (MemoryStream memo = new MemoryStream(Encoding.Unicode.GetBytes(content)))
    {
       IEnumerable<Class1> countries = (IEnumerable<Class1>)serializer.ReadObject(memo);
       int i = countries.Count();
    }
    
    Console.Read();
