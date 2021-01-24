    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _transContainer2.Items.Add(new Image
        {
            Source = new BitmapImage(new Uri("pathToYourImage")),
            Stretch = Stretch.Fill,
            Width = 200,
            Height = 200
        });
    }
 
