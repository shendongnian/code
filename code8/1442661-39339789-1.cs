    private ObservableCollection<Wares> WaresCollection = new ObservableCollection<Wares>();
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        WaresCollection.Clear();
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao4.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao5.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao6.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao4.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao5.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao6.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao4.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao5.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao6.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao4.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao5.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao6.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao4.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao5.jpg" });
        WaresCollection.Add(new Wares { WaresImage = "Assets/miao6.jpg" });
    }
    
    private void Image_Tapped(object sender, TappedRoutedEventArgs e)
    {
        FilterGrid.Visibility = Visibility.Visible;
    }
    
    private void Done_Button_Click(object sender, RoutedEventArgs e)
    {
        FilterGrid.Visibility = Visibility.Collapsed;
    }
