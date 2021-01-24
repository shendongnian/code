    public class WeatherCollection : ObservableCollection<Weather>
    {
    }
    public class Weather
    {
        public string Month { get; set; }
        public double MaxAmount { get; set; }
        public double MinAmount { get; set; }
    }
