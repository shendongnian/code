    using (Image background = Image.FromFile("background.jpg"))
    using (Image qrCode = Image.FromFile("qrCode.jpg"))
    using (Graphics graphics = Graphics.FromImage(background))
    {
        int x = 100;
        int y = 100;
        graphics.DrawImage(qrCode, x, y);
        background.Save("result.jpg", ImageFormat.Jpeg);
    }
