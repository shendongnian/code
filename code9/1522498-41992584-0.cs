    using (MultipartFormDataContent content = new MultipartFormDataContent("----------" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
    {
        content.Add(new StringContent(JsonConvert.SerializeObject(uploadReferenceRequest), Encoding.UTF8, "application/json"));
        StreamContent audioContent = new StreamContent(new MemoryStream(buffer));
        audioContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        content.Add(audioContent);
        using (HttpResponseMessage response = await this.Client.PostAsync(url, content))
        {
             string responseContent = await response.Content.ReadAsStringAsync();
                  
        }
    }
