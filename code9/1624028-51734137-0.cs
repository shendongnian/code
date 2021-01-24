    public async Task<ActionResult> GetAttachment(int FileID)
    {
        UriBuilder uriBuilder = new UriBuilder();
        uriBuilder.Scheme = "https";
        uriBuilder.Host = "api.example.com";
        var Path = "/files/download";
        uriBuilder.Path = Path;
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(uriBuilder.ToString());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("authorization", access_token); //if any
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    System.Net.Http.HttpContent content = response.Content;
                    var contentStream = await content.ReadAsStreamAsync(); // get the actual content stream
                    return File(contentStream, content_type, filename);
                }
                else
                {
                    throw new FileNotFoundException();
                }
        }
    }
