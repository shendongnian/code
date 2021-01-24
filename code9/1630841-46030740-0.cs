    if (e.DataView.Contains(StandardDataFormats.Bitmap))
    {
        try
        {
            var a = await e.DataView.GetBitmapAsync();
            var c = await a.OpenReadAsync();
            BitmapImage b = new BitmapImage();
            b.SetSource(c);
            MyCanvasImage.Source = b;
        }
        catch (Exception) { }
    }
