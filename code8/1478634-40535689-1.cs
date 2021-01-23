    protected override void OnResize(EventArgs e)
    {
    	UpdatePixelGrid();
    	base.OnResize(e);
    }
    private void CreatePixelGrid()
    {
    	// initialize pixel grid:
    	pixels = new Pixel[Columns, Rows];
    	for (int y = 0; y < Rows; ++y)
    	{
    		for (int x = 0; x < Columns; ++x)
    		{
    			pixels[x, y] = new Pixel();
    		}
    	}
    	UpdatePixelGrid();
    }
