    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        StackPanel stackPanel = new StackPanel();
        for (int i = 0; i < 3; i++)
        {
            Windows.Storage.Streams.IRandomAccessStream random = await Windows.Storage.Streams.RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/sun2set.jpg")).OpenReadAsync();
            Image image = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            StackPanel mystackPanel = new StackPanel();
            image.Name = i.ToString();
            bitmapImage.SetSource(random);
            image.Source = bitmapImage;
            mystackPanel.Children.Add(image);
            image.PointerEntered += Image_PointerEntered;
            image.PointerExited += Image_PointerExited;
            stackPanel.Children.Add(mystackPanel);
        }
        this.Results.Children.Add(stackPanel);
    }
    
    private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        var image = sender as Image;
    
        var parent = VisualTreeHelper.GetParent(image) as StackPanel;
        parent.BorderBrush = new SolidColorBrush(Colors.Red);
        parent.BorderThickness = new Thickness(0);
        image.Tapped -= Image_Tapped;
    }
    
    private void Image_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        var image = sender as Image;
        Debug.WriteLine("The" + image.Name + "is Selected!");
        var parent = VisualTreeHelper.GetParent(image) as StackPanel;
        parent.BorderBrush = new SolidColorBrush(Colors.Red);
        parent.BorderThickness = new Thickness(5);
        image.Tapped += Image_Tapped;
    }
    
    private void Image_Tapped(object sender, TappedRoutedEventArgs e)
    {
        var image = sender as Image;
        //download the image
    }
