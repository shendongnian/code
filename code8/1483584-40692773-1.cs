    private void city_button_Click(object sender, RoutedEventArgs e)
    {
        string city_name;
        city_name = city_text.Text;
        var weatherService = new WeatherRepositoryForUWP();
        string weatherData = weatherService.DownloadWeather(city_name).Result;
    }
