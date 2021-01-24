    private static T DownloadAndDeserializeJsonData<T>(string url) where T : new()
    {
        using (var webClient = new WebClient())
        {
            var jsonData = string.Empty;
            try
            {
                jsonData = webClient.DownloadString(url);
            }
            catch (Exception) { }
            return !string.IsNullOrEmpty(jsonData) 
                       ? JsonConvert.DeserializeObject<T>(json_data) 
                       : new T();
        }
    }
