    public void Upload(...)
    {
        try
        {
            using (Stream fileStream = file.InputStream)
           {
               blockBlob.UploadFromStream(fileStream);
           }
           Urls.Add(blockBlob.SnapshotQualifiedUri.ToString());
           db.Save();
        }
        catch(Exception exc)
        {
           ProcessProblem(exc);
           throw new MyUploadException(..., exc);
           // or just throw exc
        }
    }
