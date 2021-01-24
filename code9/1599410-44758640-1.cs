    static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
    {
        Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
        float a = 1f * alpha /  255f;
        Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);
        float[][] matrixItems ={ 
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, a, 0}, 
            new float[] {0, 0, 0, 0, 1}};
        ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
        ImageAttributes imageAtt = new ImageAttributes();
        imageAtt.SetColorMatrix( colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        using (Graphics g = Graphics.FromImage(bmpOut))
            g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);
        return bmpOut;
    }
