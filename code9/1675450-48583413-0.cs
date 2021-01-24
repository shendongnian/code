    public static async Task<HttpResponseMessage> PostJsonAsync<T>(
            this HttpClient client,
            string requestUri,
            T value)
        {
            var data = JsonConvert.SerializeObject(value);
            var content = new StringContent(data,
                                            Encoding.UTF8,
                                            MimeTypes.Json);
            Debug.WriteLine(client.BaseAddress + requestUri);
            return await client.PostAsync(requestUri,
                                          content)
                               .WithRequestTimeout()
                               .ConfigureAwait(false);
        }
