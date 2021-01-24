    public MainPage()
    {
        #if __IOS__
        var resourcePrefix = "Mapper.iOS";
        #endif
        #if __ANDROID__
        var resourcePrefix = "Mapper.Droid";
        #endif
        #if WINDOWS_PHONE
        var resourcePrefix = "Mapper.WinPhone";
        #endif
        var assembly = typeof(MainPage).GetTypeInfo().Assembly;
        Stream stream = assembly.GetManifestResourceStream("${resourcePrefix}.data.txt");
        string text = "";
        using (var reader = new System.IO.StreamReader(stream))
        {
            text = reader.ReadToEnd();
        }
    }
