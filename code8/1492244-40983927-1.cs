    public ResourceFontLoader(Factory factory, List<Stream> fontfiles)
    {
        _factory = factory;
        var AnyFontsLoaded = false;
        foreach (var filename in fontfiles)
        {
            try
            {
                using (filename)
                {
                    var fontBytes = Utilities.ReadStream(filename);
                    var stream = new DataStream(fontBytes.Length, true, true);
                    stream.Write(fontBytes, 0, fontBytes.Length);
                    stream.Position = 0;
                    _fontStreams.Add(new ResourceFontFileStream(stream));
                    AnyFontsLoaded = true;
                }
            }
            catch (System.Exception)
            {
                // Handle all file exceptions how you see fit
                throw;
            }
        }
        if (AnyFontsLoaded)
        {
            // Build a Key storage that stores the index of the font
            _keyStream = new DataStream(sizeof(int) * _fontStreams.Count, true, true);
            for (int i = 0; i < _fontStreams.Count; i++)
                _keyStream.Write((int)i);
            _keyStream.Position = 0;
    
            // Register the 
            _factory.RegisterFontFileLoader(this);
            _factory.RegisterFontCollectionLoader(this);
        }
    }
