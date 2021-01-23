    public string[] GetGalleryPaths(string picRootRealPath) 
    {
        if (Directory.Exists(picRootRealPath))
        {
            return Directory.GetDirectories(picRootRealPath);
        }
        else
        {
            return null;
        }
    }
    public string[] GetPhotoList(string galleryName, string picRootRealPath)
    {
        string galleryPath=picRootRealPath + "\\" + galleryName + "\\pics";
        if (Directory.Exists(galleryPath))
        {
            return Directory.GetFiles(galleryPath,"*.JPG");
        }
        else
        {
            return null;
        }
    }
