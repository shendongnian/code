    public bool SaveImage(string ImgStr, string ImgName)
    {       
        String path = HttpContext.Current.Server.MapPath("~/ImageStorage"); //Path
        //Check if directory exist
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
        }
        string imageName = ImgName + ".jpg";
        //set the image path
        string imgPath = Path.Combine(path, imageName);
        
        byte[] imageBytes = Convert.FromBase64String(base64String);
        
        File.WriteAllBytes(imgPath, imageBytes);
        return true;
    }
