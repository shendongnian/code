    void Image_Loaded(object sender, RoutedEventArgs e)
    {
        Image img = sender as Image; 
        BitmapImage bitmapImage = new BitmapImage();
        img.Width = bitmapImage.DecodePixelWidth = 80; 
        // Natural px width of image source.
        // You don't need to set Height; the system maintains aspect ratio, and calculates the other
        // dimension, as long as one dimension measurement is provided.
        bitmapImage.UriSource = new Uri(img.BaseUri,"Images/myimage.png");
    }
