    public async Task<RootObject> ShowTemp()
        {
            var http = new HttpClient();
            var url = String.Format("https://www.metaweather.com/api/location/44418/");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var ser = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)ser.ReadObject(ms);
            return data;
        }
        public async Task<ConsolidatedWeather> GetWeatherForToday()
        {
            RootObject ro = await ShowTemp();
            ConsolidatedWeather todayWeather = ro.consolidated_weather.FirstOrDefault();
            return todayWeather;
            // for getting min and max
            // todayWeather.min_temp;
            // todayWeather.max_temp;
        }
