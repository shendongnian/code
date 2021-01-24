    private static readonly string[] _validExtensions = {".jpg",".png"}; 
    public static bool IsImageExtension(string ext)
    {
            return _validExtensions.Contains(ext);
    }
