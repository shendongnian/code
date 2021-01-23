    public static double[,] Image2Matrix2(Bitmap image)
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
    			byte* scan0 = (byte*)data.Scan0;
                Parallel.For(0, data.Height, i => {
                    for (int j = 0; j < data.Width; j++)
                    {
                        byte* ptr = scan0 + (i * data.Stride + j * 3);
                        matrix[i, j] = (ptr[0] + ptr[1] + ptr[2]) / (3d * 255);
                    }
                });
                return matrix;
            }
        }
        finally
        {
            image.UnlockBits(data);
        }
    }
spender's method took : 22ms
sadegh's method took : 5284ms
