    public static class ServiceClient
    {
        public static async Task<List<T>> HttpGetList<T>(string url)
        {
            using (var client = SetupHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                CheckResponse(response);
                var tList = await response.Content.ReadAsAsync<List<T>>();
                return tList;
            }
        }
    }
