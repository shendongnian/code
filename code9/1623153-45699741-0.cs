    Bitmap bmp;
    Texture2D snap;
    using (var ms = new MemoryStream(snap.EncodeToPNG()))
    {
        bmp = new Bitmap(ms);
    }
    vFWriter.WriteVideoFrame(bmp);
