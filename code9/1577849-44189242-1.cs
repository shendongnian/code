    using Newtonsoft.Json;
    ....
    ....
    response = await client.PostAsync(uri, content);
    if (response.IsSuccessStatusCode)
    {
        Stringr str = await response.Content.ReadAsStringAsync();
    
        dynamic json = JsonConvert.DeserializeObject(str);
    }
