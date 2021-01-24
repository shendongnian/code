    System.Drawing.Imaging.ImageFormat file_format
    using(var image = System.Drawing.Image.FromFile(filename))
    {
        file_format = image.RawFormat;
    }  // the image will be disposed here, even if an exception is thrown.
