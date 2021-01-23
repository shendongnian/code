    public static double[,] Image2Matrix(Bitmap image)
    {
        if (image == null)
            throw new ArgumentNullException("image");
        var data = image.LockBits(
                      new Rectangle(0, 0, image.Width, image.Height), 
                      ImageLockMode.ReadWrite, image.PixelFormat);
    	double[,] matrix = new double[image.Height, image.Width];
        try
        {
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        matrix[i,j]=(ptr[0]+ptr[1]+ptr[2])/(3d*255);
                        ptr += 3;
                    }
    
                    ptr += data.Stride - data.Width * 3;
                }
    			return matrix;
            }
        }
        finally
        {
            image.UnlockBits(data);
        }
    }
