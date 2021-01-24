    public void AddWatermark(string inputhPath, string outputPath)
    {
        var wm = DateTime.Now.ToShortDateString();
    
        using (var bmp = Bitmap.FromFile(inputhPath))
        using (var g = Graphics.FromImage(bmp))
        using (var transparentBrush = new SolidBrush(Color.FromArgb(164, 0, 0, 0)))
        using (var font = new Font("Calibri", 20, FontStyle.Bold, GraphicsUnit.Pixel))
        {
            var format = new StringFormat(StringFormatFlags.NoWrap);
            var dim = g.MeasureString(wm, font);
            var loc = new Point(bmp.Width - (int)dim.Width - 20, bmp.Height - (int)dim.Height * 2);
    
            g.DrawString(wm, font, transparentBrush, loc);
    
            bmp.Save(outputPath);
        }
    }
