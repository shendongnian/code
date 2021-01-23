    public virtual async Task<TReturn> PostAsync<TReturn>(string resource)
    {
        var exMsg = $"Post request failed to get resource: '{resource}' from '{Client.BaseAddress}'.";
        try
        {
            HttpResponseMessage response = await Client.PostAsync(resource, null);
            if (!response.IsSuccessStatusCode)
            {
                RaiseException(response, exMsg);
            }
            return await response.Content.ReadAsAsync<TReturn>();
        }
        catch (Exception ex) when (ex.GetType() != typeof(RestClientException))
        {
            throw;
        }
    }
