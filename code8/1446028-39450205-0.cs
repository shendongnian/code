    var uri = "/temp/file.mp3";
    using (var httpClient = new HttpClient())
    {
        using (var httpRequest = new HttpRequestMessage())
        {
            string url = "https://content.dropboxapi.com/1/files/auto" + Uri.EscapeDataString(uri);
    
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    
            var response = await httpClient.SendAsync(httpRequest);
    
            if (response.IsSuccessStatusCode)
            {
                //TODO
            }
        }
    }
