    public static async Task<KeyValuePair<bool, string>> Post(string url, List<KeyValuePair<string, string>> parameters, Func<object, bool, KeyValuePair<bool, string>> callback)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();
                httpClient.BaseAddress = new Uri(url);
                var content = new FormUrlEncodedContent(parameters);
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                return callback(await response.Content.ReadAsStringAsync() as object, true);
            }
            catch (Exception e)
            {
                return callback(e as object, false);
            }
        }
