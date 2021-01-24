    public async Task<string> GetResponseJsonString(string url)
    {
        string responseJsonString = null;
    
        var req = new HttpRequestMessage(HttpMethod.Get, "/your/api/url");             
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
    
        using (var resp = await client.SendAsync(req))
        using (var s = await resp.Content.ReadAsStreamAsync())
        using (var sr = new StreamReader(s))
        {
            if (resp.IsSuccessStatusCode)
            {
                responseJsonString = await sr.ReadToEndAsync();
            }
            else
            {
                string errorMessage = await sr.ReadToEndAsync();
                int statusCode = (int)resp.StatusCode;
    
                //log your error
            }
        }    
    
        return responseJsonString;
    }
