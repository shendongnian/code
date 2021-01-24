    using (var client = new HttpClient())
    {
          client.BaseAddress = new Uri(url);
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
          string stringFromObject = JsonConvert.SerializeObject(product);
          HttpContent content = new StringContent(stringFromObject, Encoding.UTF8, "application/json");
          content.Headers.Add("YourCustomHeader", "YourParameter");
          HttpResponseMessage response = client.PostAsync(url, content).Result;
          if (response.IsSuccessStatusCode)
          {
              // do something
          }
     }
