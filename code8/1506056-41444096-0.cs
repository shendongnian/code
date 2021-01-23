    WriteableBitmap wb;
    private async void ImageOpened(object sender, RoutedEventArgs e)
    {
        wb = await BitmapFactory.New(1, 1).FromContent(((sender as Image).Source as BitmapImage).UriSource);
    }
    private async void ImageTapped(object sender, TappedRoutedEventArgs e)
    {
        var pos = e.GetPosition(sender as UIElement);
        var px = wb.GetPixel((int)pos.X, (int)pos.Y);
        System.Diagnostics.Debug.WriteLine($"R: {px.R} G: {px.G} B: {px.B} ");
    }
