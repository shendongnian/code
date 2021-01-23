    FileInfo inputImageFile = new FileInfo(@"C:\Temp\TheSimpsons.png");
    Bitmap inputImage = (Bitmap)Bitmap.FromFile(inputImageFile.FullName);
    // create blank bitmap
    Bitmap adjImage = new Bitmap(inputImage.Width, inputImage.Height);
    // create graphics object on new blank bitmap
    Graphics g = Graphics.FromImage(adjImage);
    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
        new Rectangle(0, 0, adjImage.Width, adjImage.Height),
        Color.White,
        Color.Transparent,
        0f);
    Rectangle rect = new Rectangle(0, 0, adjImage.Width, adjImage.Height);
    g.FillRectangle(linearGradientBrush, rect);
    int x;
    int y;
    for (x = 0; x < adjImage.Width; ++x)
    {
        for (y = 0; y < adjImage.Height; ++y)
        {
            Color inputPixelColor = inputImage.GetPixel(x, y);
            Color adjPixelColor = adjImage.GetPixel(x, y);
            Color newColor = Color.FromArgb(adjPixelColor.A, inputPixelColor.R, inputPixelColor.G, inputPixelColor.B);
            adjImage.SetPixel(x, y, newColor);
        }
    }
    previewPictureBox.Image = adjImage;
