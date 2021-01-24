        Image tempImage;
        using(var oldImg = Image.FromFile(PathName))
        {
           tempImage = oldImage;
        }
        if (File.Exists(PathName))
        {
            File.Delete(PathName);
        }
