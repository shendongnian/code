    using Windows.Web.Http;
    var requestMessage = new HttpRequestMessage(HttpMethod.Post,
                    new Uri(youruri));
    requestMessage.Headers.Add("Content-Type", "multipart/form-data; boundary=----WebKitFormBoundarygWsJMIUcbjwBPfeL");
    requestMessage.Content = new HttpStringContent(request);
    
    HttpClient client = new HttpClient();
    var responseMessage = await client.SendRequestAsync(requestMessage);
