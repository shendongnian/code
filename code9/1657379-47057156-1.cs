    private static async Task<T> _getjson<T>(string url) where T : new()
    {
        using (var w = new WebClient())
        {
            var json_data = string.Empty;
            // attempt to download JSON data as a string
            try
            {
                json_data = await w.DownloadStringAsync(new Uri(url));
            }
            catch (Exception) { }
            // if string with JSON data is not empty, deserialize it to class and return its instance 
            return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        }
    }
    
    public async void Button1_Click(...)
    {
        ...
        var onlineornot = ("http://example.com");
        var chatters = await _getjson<Rootobject>(onlineornot);
        ...
    }
