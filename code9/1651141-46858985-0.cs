    public Bitmap SaveTiffAsTallPng(string filePathAndName) {
        string pngFilename = Path.ChangeExtension(filePathAndName), "png");
        if (System.IO.File.Exists(pngFilename))
            return new Bitmap(pngFilename);
        else {
            Bitmap pngBitmap;
            using (FileStream tiffFileStream = File.OpenRead(filePathAndName)) {
                TiffBitmapDecoder decoder
                        = new TiffBitmapDecoder(
                                tiffFileStream,
                                BitmapCreateOptions.PreservePixelFormat,
                                BitmapCacheOption.None);
                int pngWidth = 0;
                int pngHeight = 0;
                for (int i = 0; i < decoder.Frames.Count; ++i) {
                    pngWidth = Math.Max(pngWidth, decoder.Frames[i].PixelWidth);
                    pngHeight += decoder.Frames[i].PixelHeight;
                }
                bitmap = new Bitmap(pngWidth, pngHeight, PixelFormat.Format16bppGrayScale);
                using (Graphics g = Graphics.FromImage(pngBitmap)) {
                    int y = 0;
                    for (int i = 0; i < decoder.Frames.Count; ++i) {
                        using (Bitmap frameBitMap = Worker.BitmapFromSource(decoder.Frames[i])) {
                            g.DrawImage(frameBitMap, 0, y);
                            y += frameBitMap.Height;
                        }
                    }
                }
            }
            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 16L);
            pngBitmap.Save(
                    pngFilename,
                    Worker.GetEncoderInfo("image/png"),
                    eps);
            return pngBitmap;
        }
    }
