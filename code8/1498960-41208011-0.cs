    public Bitmap ModifyAlpha(Bitmap bmap)
        {
            Bitmap bmap32 = new Bitmap(bmap.Width, bmap.Height, PixelFormat.Format32bppArgb);
    
            Color theColor = new Color();
            Color newColor = new Color();
    
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    // Get the color of the pixel at (i,j)
                    theColor = bmap.GetPixel(i, j);
    
                    // Set the pixel color/range you want to make transparent
                    if ((theColor.R > 250 && theColor.G > 250 && theColor.B > 250) ||
                        (theColor.R > 250))
                    {
                        newColor = Color.FromArgb(0, theColor.R, theColor.G, theColor.B);
                        bmap32.SetPixel(i, j, newColor);
                    } else
                    {
                        bmap32.SetPixel(i, j, theColor);
                    }
                }
            }
            return bmap32;
         }
