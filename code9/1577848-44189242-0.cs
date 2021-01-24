    using Newtonsoft.Json;
    ....
    ....
    if (response.IsSuccessStatusCode)
    {
        Stringr str = await response.Content.ReadAsStringAsync();
    
        dynamic json = JsonConvert.DeserializeObject(str);
    }
