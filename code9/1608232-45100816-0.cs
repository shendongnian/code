    public static SKBitmap Rotate()
    {
        using (var bitmap = SKBitmap.Decode("test.jpg"))
        {
            var rotated = new SKBitmap(bitmap.Height, bitmap.Width);
            using (var surface = new SKCanvas(rotated))
            {
                surface.Translate(rotated.Width, 0);
                surface.RotateDegrees(90);
                surface.DrawBitmap(bitmap, 0, 0);
            }
            return rotated;
        }
    }
