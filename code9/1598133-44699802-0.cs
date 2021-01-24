    //declare the rectangles and spritesets
    Texture2D tileSheet;
    List<Rectangle> tileSet;
    
    //load every tile, also works great
    tileSheet = Content.Load<Texture2D>(@"Tiles/Object");
    int noOfTilesX = (int)tileSheet.Width / 50;
    int noOfTilesY = (int)tileSheet.Height / 50;
    tileSet = new List<Rectangle>(noOfTilesX * noOfTilesY);
    
    // Gets the color data of the tile sheet.
    Color[] tileSheetPixels = new Color[tileSheet.Width * tileSheet.Height];
    tileSheetPixels.GetData<Color>(tileSheetPixels);
    
    for (int j = 0; j < noOfTilesY; j++)
    {
    	for (int i = 0; i < noOfTilesX; i++)
    	{
    		bounds = new Rectangle(i * 50, j * 50, 50, 50);
    		tileSet.Add(bounds);
    
    		// Creates a new texture for a single tile.
    		Texture2D singleTile = new Texture2D(graphics, 50, 50);
    		Color[] pixels = new Color[50 * 50];
    
    		// Gets the pixels that correspond to the single tile and saves them in another
    		// color array.
    		for (int k = 0; k < pixels.Length; k++)
    		{
    			pixels[k] = new Color();
    
    			int x = bounds.X;
    			x += (k % 50);
    			int y = bounds.Y;
    			y += (k / 50);
    
    			pixels[k] = tileSheetPixels[y * 50 + x];
    		}
    
    		// Sets the color data of the single tile texture to the color array
    		// created above.
    		singleTile.SetData<Color>(pixels);
    
    		//save as pngs if they do not exist
    		if (!File.Exists(@"C:\tile_" + i + "_" + j + ".png"))
    		{
    			Stream stream = File.Create(@"C:\tile_" + i + "_" + j + ".png");
        		
    			singleTile.SaveAsPng(stream, 50, 50);
    		}
    	}
    }
