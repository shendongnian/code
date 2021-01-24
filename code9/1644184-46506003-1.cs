    var picker = new FileSavePicker
    {
        SuggestedStartLocation = PickerLocationId.Desktop,
        DefaultFileExtension = ".bin",
        SuggestedFileName = "Binary file"
    };
    picker.FileTypeChoices.Add("Binary File", new List<string> { ".bin" });
    var file = await picker.PickSaveFileAsync();
    using (var stream = await file.OpenStreamForWriteAsync())
    {
        stream.SetLength(0);
        var bytes = Encoding.ASCII.GetBytes("Content");
        await stream.WriteAsync(bytes, 0, bytes.Length);
        await stream.FlushAsync();
    }
