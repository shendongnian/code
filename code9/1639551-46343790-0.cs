    public static async Task<HttpResponseMessage> do_POST(string apiPath, string auth, string json)
    {
        HttpResponseMessage response;
        using (var httpClient = new HttpClient())
        {
            var request = new StringContent(json);
            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            try{
                response = await httpClient.PostAsync(new Uri(apiBase + apiPath), request);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        return response;
    }
