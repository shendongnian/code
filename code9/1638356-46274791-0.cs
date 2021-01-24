    using (var stream= new System.IO.FileStream(ImagePath, System.IO.FileMode.Open))
    {
        var bmp= new Bitmap(stream);
        PicImage  = (Bitmap) bmp.Clone();
    }
