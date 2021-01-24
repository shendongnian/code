    if(e.Data.GetDataPresent(DataFormats.FileDrop))
    {
        var filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        image1.Source = new BitmapImage(new Uri(filename));
    }
