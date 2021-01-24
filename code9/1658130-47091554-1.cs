    public async Task StartCallingAsync()
    {
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            //do work
        }
    }
