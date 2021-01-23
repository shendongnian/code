    public bool TryUploadFile(File file)
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
