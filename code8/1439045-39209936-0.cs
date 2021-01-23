    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:38762/api/customer/AddCustome");
    client.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
     HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,"relativeAddress");
     var serializedCustomer = JsonConvert.SerializeObject(oCustomer);
                    var content = new StringContent(serializedCustomer, Encoding.UTF8, "application/json");
      request.Content = content;
      client.SendAsync(request)
      .ContinueWith(responseTask =>
      {
          Console.WriteLine("Response: {0}", responseTask.Result);
      });
