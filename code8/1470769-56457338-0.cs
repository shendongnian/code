        private static HttpClient _httpClient = new HttpClient();
        public static async Task<Stream> LoadImageFromUrl(string url)
        {
            Stream stream = null;
            try
            {
                HttpResponseMessage result = await _httpClient.GetAsync(url);
                stream = await result.Content.ReadAsStreamAsync();
            }
            catch (Exception e)
            {
                // TODO
            }
            return stream;
        }
