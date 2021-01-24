    private void SavePanel()
    {
    	Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
    	panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
    	bitmapList.Add(bmp);
    }
