    private async void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
        var deferral = args.Request.GetDeferral();
        var si = await StorageFile.CreateStreamedFileAsync("Document.pdf", stream =>
        {
            var writeStream = stream.AsStreamForWrite();
            writeStream.Write(PdfBytes, 0, PdfBytes.Length);
            stream.Dispose();    
            args.Request.Data.Properties.Title = "PDF Document";
            args.Request.Data.Properties.Description = "Some description";
            args.Request.Data.SetStorageItems(new IStorageItem[] { si });
            deferral.Complete();
            
        },  null);
    }
