    private async Task<TResponse> SendHttpRequest<TRequest, TResponse>(TRequest request)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = "http://example.com/";
            var response = await client.PostAsJsonAsync("api_path", request).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new MyException(response);
            }
            if (typeof (TResponse) == typeof (bool))
            {
                return (TResponse)(object)true;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(content);
            }
        }
    } 
