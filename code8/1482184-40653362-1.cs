    using (var client = new HttpClient())
    {
       var request = new HttpRequestMessage(HttpMethod.Get, url);
       //Let's read only 50 bytes
       request.Headers.Range = new RangeHeaderValue(0, 50);
    
       using (var response = await client.SendAsync(request))
          using (var stream= await response.Content.ReadAsStreamAsync())
          {
             //The buffer can store 1000 bytes but only 50 will be send from the server
             var buffer = new byte[1000];
             stream.Read(buffer, 0, 1000);
             //...
          }
    }
