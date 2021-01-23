    Image tempImage;
    using(var img = System.Drawing.Image.FromFile(defaultPicPath))
        tempImage=new Bitmap(img);
    using(System.Drawing.Image RoundedImage = RoundCorners(tempImg, 90, System.Drawing.Color.Transparent)) {
        RoundedImage.Save(defaultPicPath);
        tempImg.Dispose();
    
