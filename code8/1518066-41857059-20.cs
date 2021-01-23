    private static Bitmap DeskewImageByIndividualChars(Bitmap targetBitmap)
    {
        IDictionary<Rectangle, Bitmap> characters = new CCL().Process(targetBitmap);
        using (Graphics g = Graphics.FromImage(targetBitmap))
        {
            foreach (var character in characters)
            {
                double angle;
                BitmapData bitmapData = character.Value.LockBits(new Rectangle(Point.Empty, character.Value.Size), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                try
                {
                    HoughLineTransformation hlt = new HoughLineTransformation();
                    hlt.ProcessImage(bitmapData);
                    angle = hlt.GetLinesByRelativeIntensity(0.5).Average(l => l.Theta);
                }
                finally
                {
                    character.Value.UnlockBits(bitmapData);
                }
                using (Bitmap bitmap = RotateImage(character.Value, 90 - angle, Color.White))
                {
                    g.DrawImage(bitmap, character.Key.Location);
                }
            }
        }
        return targetBitmap;
    }
