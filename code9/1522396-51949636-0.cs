    using (var client = new HttpClient())
    {
        var content = new StringContent(messageToPOST, Encoding.UTF8, "text/xml");
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml");
        response = await client.PostAsync(_uri, content);
        responseMsg = await response.Content.ReadAsStringAsync();
    }
