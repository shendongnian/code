        private ObservableCollection<RootObject> weatherObjects;
        public ObservableCollection<RootObject> WeatherObjects
        {
            get { return weatherObjects; }
            set { weatherObjects= value; RaiseProperty(nameof(WeatherObjects)); }
        }
