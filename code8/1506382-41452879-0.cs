    public bool IsValidFileSelection(params string[] filenames)
    {
        if (filenames == null || filenames.Length == 0)
            return false;
        
        return filenames.All(f => f != null && 
                   (Path.GetExtension(f) == ".jpg" || Path.GetExtension(f) == ".png"))
    }
