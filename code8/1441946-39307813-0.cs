    using (HttpClient client = new HttpClient())
    {
          var response = await client.GetAsync("https://nvd.nist.gov/download/nvd-rss.xml");
    
          string xml = await response.Content.ReadAsStringAsync();
          //or as byte array if needed
          var xmlByteArray = await response.Content.ReadAsByteArrayAsync();
          //or as stream
          var xmlStream = await  response.Content.ReadAsStreamAsync();
          //write to file
           File.WriteAllBytes(@"c:\temp\test.xml", xmlByteArray)
          
     }
