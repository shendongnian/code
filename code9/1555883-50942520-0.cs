     var params= new Dictionary<string, string>();
     var url ="Please enter URLhere"; 
     params.Add("key1", "value1");
     params.Add("key2", "value2");
                 
     using (HttpClient client = new HttpClient())
      {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(dict)).Result;
                  var tokne= response.Content.ReadAsStringAsync().Result;
    }
                   
    //Get response as expected
 
