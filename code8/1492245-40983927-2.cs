    public sealed partial class MainPage : Page
    {
        public ResourceFontLoader CurrentResourceFontLoader { get; set; }
        public FontCollection CurrentFontCollection { get; set; }
        public SharpDX.DirectWrite.Factory FactoryDWrite { get; private set; }
        public List<Stream> customFontStreams { get; set; }
        public List<string> FontFamilyNames { get; set; }
        public MainPage()
        {
            customFontStreams = new List<Stream>();
            this.InitializeComponent();
        }
    
        async Task LoadCustomFonts()
        {
            await Task.Run(() =>
            {
                // Font Families
                FontFamilyNames = new List<string> { "Aileron", "Grundschrift" };
                // Character codes to check for:
                int[] codes = { 0x41, 0x6f, 0x7c, 0xc2aa, 0xD7A3 };
                FactoryDWrite = new SharpDX.DirectWrite.Factory();
                CurrentResourceFontLoader = new ResourceFontLoader(FactoryDWrite, customFontStreams);
                CurrentFontCollection = new FontCollection(FactoryDWrite, CurrentResourceFontLoader, CurrentResourceFontLoader.Key);
    
                foreach (var fontfamilyname in FontFamilyNames)
                {
                    int familyIndex;
                    CurrentFontCollection.FindFamilyName(fontfamilyname, out familyIndex);
    
                    using (var fontFamily = CurrentFontCollection.GetFontFamily(familyIndex))
                    {
                        var font = fontFamily.GetFont(0);
    
                        using (var fontface = new FontFace(font))
                        {
                            var results = fontface.GetGlyphIndices(codes);
                            for (int i = 0; i < codes.Length - 1; i++)
                            {
                                if (results[i] > 0)
                                {
                                    Debug.WriteLine("Contains the unicode character " + codes[i]);
    
                                }
                                else
                                {
                                    Debug.WriteLine("Does not contain the unicode character " + codes[i]);
                                }
                            }
                        }
                    }
    
                }
            });
    
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".otf");
            openPicker.FileTypeFilter.Add(".ttf");
            IReadOnlyList<StorageFile> files = await openPicker.PickMultipleFilesAsync();
            if (files.Count > 0)
            {
    
    
                // Application now has read/write access to the picked file(s) 
                foreach (StorageFile file in files)
                {
                    customFontStreams.Add(await file.OpenStreamForReadAsync());
                }
                await LoadCustomFonts();
            }
        }
    }
