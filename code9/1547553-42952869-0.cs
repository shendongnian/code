    private async void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
        var deferral = args.Request.GetDeferral();
    
        var tempFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("Document.pdf", CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteBytesAsync(tempFile, PdfBytes);
    
        args.Request.Data.Properties.Title = "PDF Document";
        args.Request.Data.Properties.Description = "Some description";
        args.Request.Data.SetStorageItems(new IStorageItem[] { tempFile });
    
        deferral.Complete();
    }
