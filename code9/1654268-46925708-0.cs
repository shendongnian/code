        var sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append("     ");
        sb.Append("World!");        
        var bitmap = new Bitmap(400, 200);
        var graphics = Graphics.FromImage(bitmap);
        Brush brush = new SolidBrush(Color.White);
        graphics.FillRectangle(brush, 0, 0, 400, 200);            
        var font = new Font("Arial", 12, FontStyle.Underline);
        brush = new SolidBrush(Color.Black);
        var stringformat = new StringFormat(StringFormat.GenericTypographic);
        stringformat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
        stringformat.Trimming = StringTrimming.None;
        var text = sb.ToString();                          
        var sizeF = graphics.MeasureString(text, font, new PointF(0, 0), stringformat);
        graphics.DrawString(text, font, brush, 
                             new RectangleF(5, 0, sizeF.Width, sizeF.Height), stringformat);
