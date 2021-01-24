    using(var image = new Bitmap(filePath))
    {
    	PropertyItem propertie = image.PropertyItems.FirstOrDefault(p => p.Id == 274);
    	if (propertie != null)
    	{
    		int orientation = propertie.Value[0];
    		if (orientation == 6)
    			image.RotateFlip(RotateFlipType.Rotate90FlipNone);
    		if (orientation == 8)
    			image.RotateFlip(RotateFlipType.Rotate270FlipNone);
    	}
    }
