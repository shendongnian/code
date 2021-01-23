    bool IsEmpty(Bitmap image)
    {
        var data = image.LockBits(new Rectangle(0,0, image.Width,image.Height),
            ImageLockMode.ReadOnly, image.PixelFormat);
        var bytes = new byte[data.Height * data.Stride];
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        image.UnlockBits(data);
        return bytes.All(x => x == 0);
    }
