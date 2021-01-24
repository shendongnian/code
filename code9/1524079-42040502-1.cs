    client.DefaultRequestHeaders.Add("Sender", "id=" + fcmDetails.PROJECT_KEY);
    Use the sample code
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/");
    client.DefaultRequestHeaders
                          .Accept
                          .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                    
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + fcmDetails.SERVER_API_KEY);
                    client.DefaultRequestHeaders.Add("Sender","id=" +  fcmDetails.PROJECT_KEY);
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
                    var data = new
                    {
                        to = DeviceID,
                        notification = new
                        {
                            body = "This is the message",
                            title = "This is the title",
                            icon = "myicon"
                        }
                    };
        
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(data);
                    request.Content = new StringContent(json,
                                                        Encoding.UTF8,
                                                        "application/json");//CONTENT-TYPE header
                    
                    var data1 = client.PostAsync("send", request.Content);
                    var d = data1.Result.Content.ReadAsStringAsync();
    
    
