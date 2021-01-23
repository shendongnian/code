    var client = new HttpClient();
    var message = new HttpRequestMessage(HttpMethod.Get, "http://www.bigfont.ca");
    message.Content = new StringContent(string.Empty);
    message.Content.Headers.Clear();
    message.Content.Headers.Add("Content-Type", "application/json");
    var result = client.SendAsync(message).Result;
