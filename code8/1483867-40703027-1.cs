    class Class1 : TextBox
    {
        ...
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GenerateImg(e.Graphics);
        }
	private static void GenerateImg(Graphics g, string text, Color bg_color, Color txt_color, float font_size)
    	{
            int _width = width;
            int _height = height;
            float cordX = (width / 2) - ((width / 2) / 2) / 2;
            float cordY = (heigh / 2) - ((heigh / 2) / 2) / 2;
            Font font = new Font("Verdana", font_size, FontStyle.Bold, GraphicsUnit.Point);
            Graphics graphics = g;
            graphics.Clear(bg_color);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, new SolidBrush(txt_color), cordX, cordY);
            graphics.Flush();
	}
	...
    }
