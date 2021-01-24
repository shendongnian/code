    var bitmap = new BitmapImage();
    try
    {
        bitmap.BeginInit();
        bitmap.UriSource = new Uri("test.txt", UriKind.RelativeOrAbsolute);
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.EndInit();
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
 
