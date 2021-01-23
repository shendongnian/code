    using (var client = GetHttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(requestUri);
    
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadAsAsync<IList<T>>().ConfigureAwait(false);
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }
