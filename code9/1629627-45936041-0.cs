    public MainPage()
    {
        InitializeComponent();
        
        //Order the contacts
        var sorted = kontakter.OrderBy(x => x.Fuldenavn)
                              .ToList();
        //Set the ItemsSource with the ordered contacts
        NameslistView.ItemsSource = sorted;
    }
