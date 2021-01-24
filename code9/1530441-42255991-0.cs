    HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, "/api/devices/data");
    msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    msg.Content = new StringContent(myQueueItem, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();
    string json = await response.Content.ReadAsStringAsync();
