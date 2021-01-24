    public void CompressAndSaveBitmap(Bitmap bitmap)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (FileStream file = new FileStream("XYZ", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Bmp);
                        // tried these but they don't work.
                        //memStream.Seek(0, 0);
                        //memStream.Position = 0; 
    
                        SevenZipCompressor compressor =
                            new SevenZipCompressor
                            {
                                CompressionLevel = CompressionLevel.Ultra,
                                CompressionMethod = CompressionMethod.Lzma
                            };
    
                        compressor.CompressStream(memStream, file); // throws error here
                    }
                }
            }
