    public static Bitmap MakeChromaChange(Bitmap bmp0, Color tCol, float gamma)
    {
        Bitmap bmp1 = new Bitmap(bmp0.Width, bmp0.Height);
        using (Graphics g = Graphics.FromImage(bmp1))
        {
            float f = (tCol.R + tCol.G + tCol.B) / 765f;
            float tr = tCol.R / 255f - f;
            float tg = tCol.G / 255f - f;
            float tb = tCol.B / 255f - f;
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {  new float[] {1f + tr, 0, 0, 0, 0},
               new float[] {0, 1f + tg, 0, 0, 0},
               new float[] {0, 0, 1f + tb, 0, 0},
               new float[] {0, 0, 0, 1, 0},
               new float[] {0, 0, 0, 0, 1}  });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetGamma(gamma);
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(bmp0, new Rectangle(0, 0, bmp0.Width, bmp0.Height),
                0, 0, bmp0.Width, bmp0.Height, GraphicsUnit.Pixel, attributes);
        }
        return bmp1;
    }
