    protected override async void OnAppearing()
    {
        adverts = new List<Adverts>();
    
        if (CrossConnectivity.Current.IsConnected)
        {
            var content = await _client.GetStringAsync(Url);
            var adv = JsonConvert.DeserializeObject<List<Adverts>>(content);
    
            adverts = new ObservableCollection<Adverts>(adv);
        }
        else
        {
            // TODO: Either show cached adverts here, or hide your carrousel or whatever you want to do when there is no connection
        }
    
        AdvertsCarousel.ItemsSource = adverts;
    
        // attaching auto sliding on to carouselView 
        Device.StartTimer(TimeSpan.FromSeconds(18), () =>
        {
            SlidePosition++;
            if (SlidePosition == adverts.Count)
                SlidePosition = 0;
            AdvertsCarousel.Position = SlidePosition;
            return true;
        });
    }
