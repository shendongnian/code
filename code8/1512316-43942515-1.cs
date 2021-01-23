        public double MeasureTextHeight(string text, ExcelFont font, int width)
        {
            if (string.IsNullOrEmpty(text)) return 0.0;
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var pixelWidth = Convert.ToInt32(width * 7.5);  //7.5 pixels per excel column width
            var drawingFont = new Font(font.Name, font.Size);
            var size = graphics.MeasureString(text, drawingFont, pixelWidth);
            //72 DPI and 96 points per inch.  Excel height in points with max of 409 per Excel requirements.
            return Math.Min(Convert.ToDouble(size.Height) * 72 / 96, 409);
        }
