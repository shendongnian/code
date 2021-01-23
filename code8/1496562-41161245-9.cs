    private static Bitmap GetIconImage(string szIcon, Color clrBackground)
    {
    	// Convert an embedded icon into an image
    
    	// Load icon
    	string szImage = ("YOUR-PROJECT.Resources.Icons." + szIcon + ".ico");
    	Assembly _assembly = Assembly.GetExecutingAssembly();
    	Stream file = _assembly.GetManifestResourceStream(szImage);
    	Icon icoTmp = new Icon(file);
    
    	// Create new image
    	Bitmap bmpNewIcon = new Bitmap(icoTmp.Width, icoTmp.Height, PixelFormat.Format32bppRgb);
    
    	// Create a graphics context and set the background colour
    	Graphics g = Graphics.FromImage(bmpNewIcon);
    	g.Clear(clrBackground);
    
    	// Draw current icon onto the bitmap
    	g.DrawIcon(icoTmp, 0, 0);
    
    	// Clean up...
    	g.Dispose();
    
    	// Return the new image
    	return bmpNewIcon;
    }
