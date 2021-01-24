    Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
    Graphics graphics = Graphics.FromImage(bitmap);
    var pen = new Pen(lineColor, widthLine);
    graphics.FillRectangle(new SolidBrush(bgColor), new Rectangle(0, 0, width, height));
