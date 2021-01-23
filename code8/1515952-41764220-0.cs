    string url = 'your url here';
    using (HttpClient client = new HttpClient())
    {
         using (HttpResponseMessage response = client.GetAsync(url).Result)
         {
              using (HttpContent content = response.Content)
              {
                  var json = content.ReadAsStringAsync().Result;
              }
         }
    }
