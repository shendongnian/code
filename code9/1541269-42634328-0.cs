    public RawImage rawImage;
    Texture2D[] textures = null;
    
    //Search for files
    DirectoryInfo dir = new DirectoryInfo(@"C:\medias");
    string[] extensions = new[] { ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".ogg", ".OGG" };
    FileInfo[] info = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
    
    //Init Array
    textures = new Texture2D[info.Length];
    
    
    for (int i = 0; i < info.Length; i++)
    {
        MemoryStream dest = new MemoryStream();
    
        //Read from each Image File
        using (Stream source = info[i].OpenRead())
        {
            byte[] buffer = new byte[2048];
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                dest.Write(buffer, 0, bytesRead);
            }
        }
    
        byte[] imageBytes = dest.ToArray();
    
        //Create new Texture2D
        Texture2D tempTexture = new Texture2D(2, 2);
    
        //Load the Image Byte to Texture2D
        tempTexture.LoadImage(imageBytes);
    
        //Put the Texture2D to the Array
        textures[i] = tempTexture;
    }
    
    //Load to Rawmage?
    rawImage.texture = textures[0];
