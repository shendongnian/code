    public class WeatherRepositoryForUWP
    {
        private string urlFormat = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=imperial&APPID=274c6def18f89eb1d9a444822d2574b5";
        public async Task<string> DownloadWeather(string city)
        {
            return await FetchAsync(string.Format(urlFormat, city));
        }
        // Rest of class remains unchanged....
    }
