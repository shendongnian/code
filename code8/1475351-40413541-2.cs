    public static bool TryUploadFile(this CloudBlockBlob blockBlob, File file)
        try
        {
           using (Stream fileStream = file.InputStream)
           {
               blockBlob.UploadFromStream(fileStream);
           }
    
           return true;
        }
        catch(Exception)
        {
          //do some logging or other error handling
        }
    
        return false;
    }
