    FileInfo inputImageFile = new FileInfo(@"C:\Temp\TheSimpsons.png");
    Bitmap inputImage = (Bitmap)Bitmap.FromFile(inputImageFile.FullName);
    // create blank bitmap with same size
    Bitmap combinedImage = new Bitmap(inputImage.Width, inputImage.Height);
    // create graphics object on new blank bitmap
    Graphics g = Graphics.FromImage(combinedImage);
            
    // also use the same size for the gradient brush and for the FillRectangle function
    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
        new Rectangle(0,0,combinedImage.Width, combinedImage.Height),
        Color.FromArgb(255, Color.White), //Color.White,
        Color.FromArgb(0, Color.White), // Color.Transparent,
        0f);
    g.FillRectangle(linearGradientBrush, 0, 0, combinedImage.Width, combinedImage.Height);
    g.DrawImage(inputImage, 0,0);
    previewPictureBox.Image = combinedImage;
