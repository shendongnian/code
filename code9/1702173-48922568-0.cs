    static class Forecast
    {
        public static async void GetWeather()
        {
            var uri = new Uri("MY API URI HERE");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    using (IHttpContent content = response.Content)
                    {
                         var json = await content.ReadAsStringAsync();
    
                        var result = JsonConvert.DeserializeObject<RootObject>(json);
                        Debug.WriteLine("In async method");
                    }
                }
            }
        }
    }
