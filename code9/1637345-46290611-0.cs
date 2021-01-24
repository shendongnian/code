    private Bitmap CreateBitmap(int w, int h)
    {
        Bitmap bitmap = Bitmap.CreateBitmap(w, h, Config.Argb8888);
        int[] pixels = new int[w * h];
        for (int x = 0; x < w * h; x++)
        {
            pixels[x] = Color.Blue.ToArgb();
        }
        bitmap.SetPixels(pixels, 0, w, 0, 0, w, h);
        return bitmap;
    }
