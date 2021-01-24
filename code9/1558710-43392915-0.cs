    private Image DrawText(String text, Font font, int size, Color textColor, Color backColor)
    {
        var path = new GraphicsPath();
        path.AddString(text, font.FontFamily, (int)font.Style, size, new Point(0, 0), StringFormat.GenericTypographic);
        var area = Rectangle.Round(path.GetBounds());
    
        Rectangle br = Rectangle.Round(path.GetBounds());
        var img = new Bitmap(br.Width, br.Height);
    
        var drawing = Graphics.FromImage(img);
        drawing.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        drawing.SmoothingMode = SmoothingMode.HighSpeed;
        drawing.Clear(backColor);
    
        drawing.TranslateTransform((img.Width - br.Width) / 2 - br.X, (img.Height - br.Height) / 2 - br.Y);
        drawing.FillPath(Brushes.Black, path);
        Brush textBrush = new SolidBrush(textColor);
    
        drawing.Save();
    
        textBrush.Dispose();
        drawing.Dispose();
    
        return img;
    }
