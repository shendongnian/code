    Bitmap cloneImage = null;
    using (Bitmap bitMapImage = new Bitmap(file))
    {
        cloneImage = new Bitmap(bitMapImage);
    }
    using (cloneImage)
    {
        Graphics graphicImage = Graphics.FromImage(cloneImage);
        graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
        graphicImage.DrawString("That's my boy!", new Font("Arial", 12, FontStyle.Bold), SystemBrushes.WindowText, new Point(100, 250));
        graphicImage.DrawArc(new Pen(Color.Red, 3), 90, 235, 150, 50, 0, 360);
        System.IO.File.Delete(file);
        cloneImage.Save(file, ImageFormat.Jpeg);
    }
