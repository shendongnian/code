    var aquaBox = new BoxView
    {
        Color = Color.Aqua,
        HeightRequest = 150
    };
    
    var silverBox = new BoxView
    {
        Color = Color.Silver
    };
    
    var grid = new Grid { RowSpacing = 0 };
    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
    
    grid.Children.Add(aquaBox, 0, 0);
    grid.Children.Add(silverBox, 0, 1);
    
    Content = grid;
