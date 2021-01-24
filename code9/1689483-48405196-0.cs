    public async void SendFile()
    {
        using (System.IO.FileStream stream = System.IO.File.Open(@"c:\file.txt", System.IO.FileMode.Open))
        {
            var content = new System.Net.Http.MultipartFormDataContent();
            content.Add(new System.Net.Http.StreamContent(stream),
                    "\"file\"",
                    "Path to your file (ex: c:\temp\file.txt");
    
            await PostItemAsyncWithToken("url to post", content, "accessToken");
        }
    }
    
    public async System.Threading.Tasks.Task<bool> PostItemAsyncWithToken(string url, System.Net.Http.HttpContent content, string accessToken)
    {
        try
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                System.Net.Http.HttpResponseMessage response = await httpClient.PostAsync(url, content).ConfigureAwait(false);
    
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (System.Exception ex)
        {
            throw new System.Exception("Error message", ex);
        }
    }
