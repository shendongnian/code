    public static Bitmap ChangeColor(Bitmap scrBitmap, Color newColor)
    {
	    // make an empty bitmap the same size as scrBitmap  
	    Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
	    for (int i = 0; i < scrBitmap.Width; i++) {
		    for (int j = 0; j < scrBitmap.Height; j++) {
			    // get the pixel from the scrBitmap image  
			    var actualColor = scrBitmap.GetPixel(i, j);
                // invert colors, since we want to tint the dark parts and not the bright ones
			    var invertedOriginalR = 255 - actualColor.R;
			    var invertedOriginalG = 255 - actualColor.G;
			    var invertedOriginalB = 255 - actualColor.B;
                // multiply source by destination color (as float channels)
			    int r = (invertedOriginalR / 255) * (newColor.R / 255) * 255;
			    int g = (invertedOriginalG / 255) * (newColor.G / 255) * 255;
			    int b = (invertedOriginalB / 255) * (newColor.B / 255) * 255;
			    var tintedColor = Color.FromArgb(r, g, b);
			    newBitmap.SetPixel(i, j, tintedColor);
		    }
	    }
	    return newBitmap;
    }
