    Image sampleTiffImage = Image.FromFile(@"C:\SomeExample.tif");
    int pageCount = sampleTiffImage.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
    for (int pageNum = 0; pageNum < pageCount; pageNum++)
    {
        sampleTiffImage.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, pageNum);
        using (MemoryStream memStream = new MemoryStream())
        {
            sampleTiffImage.Save(memStream, ImageFormat.Bmp);
            using (Bitmap myBitmap = (Bitmap)Bitmap.FromStream(memStream))
            {
                myBitmap.Save(@"C:\someFol\" + pageNum + ".bmp");
                // note: the above line is saving to disk.  I'm doing it for testing purposes,
                // but you're going to want to copy it to your array.
            }
        }
    }
