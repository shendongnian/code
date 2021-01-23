    public string FileToBase64(string Path)
    {
        byte[] imageArray = System.IO.File.ReadAllBytes(Path);
        return Convert.ToBase64String(imageArray);
    }
