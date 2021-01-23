    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var temp = new BitmapImage();
        var assembly = typeof(ImageTest.App).GetTypeInfo().Assembly;
        Stream stream = assembly.GetManifestResourceStream(value as string);
        if (stream != null)
        {
            using (var memStream = new MemoryStream())
            {
                stream.CopyTo(memStream);
                memStream.Position = 0;
                temp.SetSource(memStream.AsRandomAccessStream());
            }
        }
        return temp;
    }
