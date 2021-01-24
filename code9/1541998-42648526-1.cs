    private void CreateLetterBitmap(char letter, string path)
    {
        using (var bmp = new Bitmap(13, 13))
        using (var gfx = Graphics.FromImage(bmp))
        using (var font = new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Bold, GraphicsUnit.Pixel))
        {
            gfx.TextRenderingHint = TextRenderingHint.AntiAlias;
            gfx.DrawString(letter.ToString(), font, Brushes.Black, new Point(0, 0));
            bmp.Save(path, ImageFormat.Png);
        }
    }
    private void PrepareChart()
    {
        CreateLetterBitmap('A', "a.png");
        CreateLetterBitmap('B', "b.png");
        chart.Series[0].MarkerImage = "a.png";
        chart.Series[0].Points[2].MarkerImage = "b.png";
        chart.Series[0].Points[4].MarkerImage = "b.png";
    }
