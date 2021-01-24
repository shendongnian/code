    static class Forecast
    {
        public static RootObject Result {get; private set;}
        public static async Task GetWeatherAsync()
        {
            var uri = new Uri("MY API URI HERE");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    using (IHttpContent content = response.Content)
                    {
                        var json = await content.ReadAsStringAsync();
    
                        Result = JsonConvert.DeserializeObject<RootObject>(json);
                        Debug.WriteLine("In async method");
                    }
                }
            }
        }
    }
