    Font font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
                    
    int x = 10, y = 10, width = 120, height = 30, breakLen = 0;
    Rectangle box;
    string text = "THIS BOX IS TOO TALL!!!";
    private void DrawRectangle()
    {
    	box = new Rectangle(x, y, width, height);
    
    	using (Graphics g = this.CreateGraphics())
    	{
    		double cwidth = g.MeasureString("h", SystemFonts.DefaultFont).Width;
    		breakLen = (int)((double)box.Width / (double)cwidth);
    
    		StringBuilder sb = new StringBuilder(text);
    		int numAppended = 0;
    
    		for (int i = 0; i < text.Length; i++)
    		{
    			if ((i + 1) % breakLen == 0)
    			{
    				sb.Insert((i + 1 + numAppended), "\n");
    				numAppended += 1;
    			}
    		}
    
    		Size s = TextRenderer.MeasureText(sb.ToString(), font);
    		height = s.Height;
    		box = new Rectangle(x, y, width, height);
    
    		Pen pen = new Pen(Color.Black, 2);
    		g.DrawString(sb.ToString(), font, Brushes.Blue, box);
    		g.DrawRectangle(pen, box);
    		pen.Dispose();
    	}
    }
