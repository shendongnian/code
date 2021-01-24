    public IActionResult Start()
        {
    
    
         var jsonRequest = Json(new { ServerId = "1", ServerPort = "27015" }).Value.ToString();
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://13.77.102.81/api/mta/start ");
                        client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                        
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
                         
                        request.Content = new StringContent(jsonRequest,
                                                            Encoding.UTF8,
                                                            "application/json");//CONTENT-TYPE header
        
                        client.SendAsync(request)
                              .ContinueWith(responseTask =>
                              {
                                   //here your response 
                                  Debug.WriteLine("Response: {0}", responseTask.Result);
                              });
            return View();
        }
