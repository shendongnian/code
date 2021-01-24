    public HttpResponseMessage Put(Pizza pizza)
    {
        string pizzaApi = "Api/Pizza/";   
        var handler = new WebRequestHandler() {  
            AllowAutoRedirect = false,  
            UseProxy = false };
        
         // no clue what type this should be so change var to the type accordingly
        var result;
        
        using( var client = new HttpClient(handler)) 
        {  
          client.BaseAdresse = new Uri("http://localhost:12345");   
          var media = new MediaTypeWithQualityHeaderValue("application/json");  
          client.DefaultRequestHeaders.Accept.Add(media);  
          result = client.PutAsJsonAsync(pizzaApi, pizza).
              ContinueWith(x => x.Result.EnsureSuccessStatusCode)).Result;
         } // end using here instead
         return result;  
        
    } // end put
