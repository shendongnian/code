    public void SaveImage(string base64img, string outputImgFilename = "image.jpg")
    {
       var folderPath = System.IO.Path.Combine(_env.WebRootPath, "imgs");
       if (!System.IO.Directory.Exists(folderPath))
       {
          System.IO.Directory.CreateDirectory(folderPath);
       }
       System.IO.File.WriteAllBytes(Path.Combine(folderPath, outputImgFilename), Convert.FromBase64String(base64img));
    }
