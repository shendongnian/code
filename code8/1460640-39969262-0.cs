    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        Point p = await getImageDimensions("ms-appx:///Assets/NewSpaceBackground.png");
        Debug.WriteLine("p.X: " + p.X + " p.Y: " + p.Y);
        Rectangle backgroundRect1 = new Rectangle();
        ImageBrush imgBrushBackground1 = new ImageBrush();
        imgBrushBackground1.ImageSource = new BitmapImage(new Uri(@"ms-appx:///Images/image03.jpg"));
        backgroundRect1.Fill = imgBrushBackground1;
        ...
    }
