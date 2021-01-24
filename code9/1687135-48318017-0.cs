    public DailyCarouselPage()
    {
        ObservableCollection<ListView> collection = new ObservableCollection<ListView>();
    
        ListView myListView = new ListView
        {
            ItemTemplate = new DataTemplate(typeof(AppointmentCellTemplate)),
            ItemsSource = (new DailyAppointmentList()).list
        };
    
        collection.Add(myListView);
        collection.Add(myListView);
    
        carousel = new CarouselViewControl();
        carousel.ItemsSource = collection;
    
        Content = carousel;
    }
