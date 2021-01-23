       private static async Task<string> GetRequestContentAsString(string url)
        {
            var data = string.Empty;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var stream = response.Content;
                    data = await stream.ReadAsStringAsync();
                }
            }
            return data;
        }
