    public MainPage()
    {
        this.InitializeComponent();
        MyWebView.ScriptNotify += MyWebView_ScriptNotify;
    }
    
    private void MyWebView_ScriptNotify(object sender, NotifyEventArgs e)
    {
        var saveText = e.Value.ToString();
    }
    
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
        open.SuggestedStartLocation =
            Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
        open.FileTypeFilter.Add(".rtf");
        open.FileTypeFilter.Add(".txt");
    
        Windows.Storage.StorageFile file = await open.PickSingleFileAsync();
    
        var Content = await readFile(file);
        string[] args = { Content };
        await MyWebView.InvokeScriptAsync("SetText", args);
    
    }
    private async Task<string> readFile(StorageFile file)
    {
        string charSet = null;
    
        try
        {
            await Task.Run(async () =>
            {
                try
                {
                    using (var fs = await file.OpenAsync(FileAccessMode.Read))
                    {
                        var tem = fs.AsStream();
                        Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                        cdet.Feed(tem);
                        cdet.DataEnd();
                        charSet = cdet.Charset;
                    }
                }
                catch (Exception ex)
                {
                }
            });
        }
        catch (Exception e)
        {
        }
    
      //  var rtf = PlainTextToRtf(Content);
        //   Classes.File._lastEncoding = charSet;
    
        IBuffer buffer = await FileIO.ReadBufferAsync(file);
        DataReader reader = DataReader.FromBuffer(buffer);
        byte[] fileContent = new byte[reader.UnconsumedBufferLength];
        reader.ReadBytes(fileContent);
        string content = "";
        if (charSet == "windows-1252")
        {
            content = Encoding.GetEncoding("iso-8859-1").GetString(fileContent, 0, fileContent.Length);
        }
        else if (charSet == "UTF-16LE")
        {
            content = Encoding.Unicode.GetString(fileContent, 0, fileContent.Length);
        }
        else if (charSet == "UTF-16BE")
        {
            content = Encoding.BigEndianUnicode.GetString(fileContent, 0, fileContent.Length);
        }
        else
        {
            content = Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
        }
    
        return content;
    }
    
    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        await MyWebView.InvokeScriptAsync("SaveText", null);
    }
