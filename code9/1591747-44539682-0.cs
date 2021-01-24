    void PrintPage(object sender, PrintPageEventArgs ev)
		{
			Graphics gr = ev.Graphics;
			gr.PageUnit = GraphicsUnit.Pixel; //this has been changed to Pixel, from Inch.
            float dpi = gr.DpiX;
            //if (dpi > 300) dpi = 300;
			Rectangle rectPage = ev.PageBounds;         //print without margins
			//Rectangle rectPage = ev.MarginBounds;     //print using margins
			 float dpi = gr.DpiX;
			int example = 1;
			bool use_hard_margins = false;
			// Example 1) Print the Bitmap.
			if (example == 1)
			{
				pdfdraw.SetDPI(dpi);
                pdfdraw.SetDrawAnnotations(false);
				Bitmap bmp = pdfdraw.GetBitmap(pageitr.Current());
			    
                gr.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
			}
    `
