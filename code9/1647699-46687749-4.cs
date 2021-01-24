    using (var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json"))
    using (var compressedContent = new CompressedContent(httpContent, "gzip"))
    using (HttpResponseMessage response = client.PostAsync("Controller/Action", compressedContent).Result)
    {
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(string.Format("Invalid responsecode for http request response {0}: {1}", response.StatusCode, response.ReasonPhrase));
        }
    }
