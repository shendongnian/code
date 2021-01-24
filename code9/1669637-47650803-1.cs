    public MainPage()
    {
        this.InitializeComponent();
        collection = new ObservableCollection<List>();
        this.DataContext = this;
    }
    
    public ObservableCollection<List> collection { get; set; }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var position1 = await LocationManager.GetPosition();
        var latitude1 = position1.Coordinate.Latitude;
        var longitude1 = position1.Coordinate.Longitude;
        RootObject forecast = await WeatherForecast.GetWeatherForecast(latitude1, longitude1);
    
        for (int i = 0; i < 5; i++)
        {
    
            collection.Add(forecast.list[i]);
        }
    
        ForecastGridView.ItemsSource = collection;
    
    }
 
