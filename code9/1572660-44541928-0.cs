    public async Task<T> SendAndReciveAsync<T>(string postData, string endpoint)
    {
        using (var client = new System.Net.Http.HttpClient())
        {
            var data = System.Text.Encoding.UTF8.GetBytes(postData);
                
            var content = new System.Net.Http.ByteArrayContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            content.Headers.ContentLength = data.Length;
            var response = await client.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var recivedContent = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(recivedContent));
         }
    }
