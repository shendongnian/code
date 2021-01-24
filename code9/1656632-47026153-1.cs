    namespace WeatherPanel
    {
	    public sealed partial class MainPage : Page, INotifyPropertyChanged
	    {
		    public Weather Weather { get; set; }
		    static HttpClient client = new HttpClient();
	    
		    private async void GetData()
		    {
		    // Get latitude, longitude, and other IP-related data.
		    IP ip = await Task.Run(() => GetIP());
		    
		    // Get current weather and forecast.
		    string weather_url = BuildWeatherUrl("forecast", ip.lat, ip.lon);
		    this.Weather = await Task.Run(() => GetWeather(weather_url));
		    
		    // This works, so we know we're getting weather data.
		    // Debug.WriteLine("--- Distance = " + this.Weather.query.results.channel.units.distance);
		    }
	    
		    public MainPage()
		    {
		    // Initializes the GUI: sets up buttons, labels, event handlers, etc.
		    this.InitializeComponent();
		    this.Weather = new Weather();
		    
		    // Get location and weather. Meanwhile, execution continues so UI thread isn't blocked.
		    GetData();
		    NotifyPropertyChanged(nameof(Weather)); //Raise the event
		    }
		    //the event to raise on changes
		    public event PropertyChangedEventHandler PropertyChanged;
		
		    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        	{
            	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        	}
	    }
    }
