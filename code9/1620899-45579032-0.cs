    //I might be called multiple times during the upload process.
    public void OnStatusUpdate(ulong bytesWritten)
    {
        Console.WriteLine(bytesWritten);
    }
    ...
        //later
        client.UploadFile(fileStream, Path.GetFileName(uploadfile), OnStatusUpdate);
