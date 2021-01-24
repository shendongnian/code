    IEnumerable<Bitmap> frames = GetFrames();
    using (var writer = new VideoWriter(target), new Size(width, height)))
    {
        foreach (var bitmap in frames)
        {
            var imageBuffer = bitmap.ToBgr();
            writer.Write(imageBuffer.Lock());
        }
    }
