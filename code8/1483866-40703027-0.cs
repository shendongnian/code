    class Class1 : TextBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bmpImg = new Bitmap(1, 1);
            int _width = width;
            int _height = height;
            float cordX = (width / 2) - ((width / 2) / 2) / 2;
            float cordY = (heigh / 2) - ((heigh / 2) / 2) / 2;
            Font font = new Font("Verdana", font_size, FontStyle.Bold, GraphicsUnit.Point);
            Graphics graphics = e.Graphics;
            bmpImg = new Bitmap(bmpImg, new Size(_width, _height));
            graphics = Graphics.FromImage(bmpImg);
            graphics.Clear(bg_color);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, new SolidBrush(txt_color), cordX, cordY);
            graphics.Flush();
        }
    }
