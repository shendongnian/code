    string rtf = "";
    Richbox.Document.Selection.GetText(TextGetOptions.FormatRtf, out rtf); 
    string imageDataHex = "";
    var r = new Regex(@"pict[\s\S]+?[\r\n](?<imagedata>[\s\S]+)[\r\n]\}\\par", RegexOptions.None);
    var m = r.Match(rtf);
    if (m.Success)
    {
        imageDataHex = (m.Groups["imagedata"].Value;
    }  
    byte[] imageBuffer = ToBinary(imageDataHex);
    StorageFile tempfile = await ApplicationData.Current.LocalFolder.CreateFileAsync("temppic.jpg");
    await FileIO.WriteBufferAsync(tempfile, imageBuffer.AsBuffer());
