    private void DeleteFile(string FileName)
    {
        // make file path
        string path = Server.MapPath(FileName);
        
        // check if file exist
        if (File.Exists(path))
        {
            // delete file from folder
            File.Delete(path);
        }
    }
