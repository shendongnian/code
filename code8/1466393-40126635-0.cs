    using(var tempImg = System.Drawing.Image.FromFile(defaultPicPath))
    using(System.Drawing.Image RoundedImage = RoundCorners(tempImg, 90, System.Drawing.Color.Transparent)) {
        RoundedImage.Save(defaultPicPath);
        tempImg.Dispose();
    
