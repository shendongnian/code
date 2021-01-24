    public static ImageFormat ParseImageFormat(string str)
    {
        return (ImageFormat)typeof(ImageFormat)
                .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                .GetValue(null);
    }
