    try
    {
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
             var json = await response.Content.ReadAsStringAsync();
        }
        else
        {
            string content = null;
            if (response.Content != null)
            {
                content = await response.Content.ReadAsStringAsync();
            }
        }
        
    }
    catch (Exception ex){}
