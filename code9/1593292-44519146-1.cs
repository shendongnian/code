    private void SaveGif()
    {
    	System.Windows.Media.Imaging.GifBitmapEncoder gEnc = new System.Windows.Media.Imaging.GifBitmapEncoder();
    	foreach (var bmp in bitmapList)
    	{
    		var hbmp = bmp.GetHbitmap();
    		var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbmp, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    		gEnc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(src));
    	}
    
    	using (FileStream fs = new FileStream(@"C:\panel1.gif", FileMode.Create))
    	{
    		gEnc.Save(fs);
    	}
    	bitmapList.Clear();
    }
