        public ImageSource AdjustBrightness(BitmapImage Image, int Value, int mod)
        {
            Bitmap TempBitmap = BitmapImage2Bitmap(Image);
            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);
            float FinalValue = (float)Value / 255.0f;
            float[][] FloatColorMatrix ={
                     new float[] {1, 0, 0, 0, 0},
                     new float[] {0, 1, 0, 0, 0},
                     new float[] {0, 0, 1, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {mod * FinalValue, mod * FinalValue, mod * FinalValue, 1, 1}
                 };
            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return Bitmap2BitmapImage(NewBitmap);
        }
