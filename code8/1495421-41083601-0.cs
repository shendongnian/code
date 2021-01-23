    private static ConcurrentDictionary<string, BitmapSource> iconDictionary = new ConcurrentDictionary<string, BitmapSource>();
    
    public static BitmapSource GetFileIcon(FileInfo fileInfo)
    {
        BitmapSource bitMapSource;
        if (iconDictionary.TryGetValue(fileInfo.Extension, out bitMapSource))
        {
            return bitMapSource;
        }
        else
        {
            lock (iconDictionary)
            {
                if (iconDictionary.TryGetValue(fileInfo.Extension, out bitMapSource))
                    return bitMapSource;
    
                Icon icon = Icon.ExtractAssociatedIcon(fileInfo.FullName);
                bitMapSource = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromEmptyOptions());
                bitMapSource.Freeze();//Allows BitmapSource to be used on another thread
                iconDictionary[fileInfo.Extension] = bitMapSource;
                return bitMapSource;
            }
        }
    }
