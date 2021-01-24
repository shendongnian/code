    private byte[] BitmapSourceToByteArray(BitmapSource bmpSrc)
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.QualityLevel = 100;
    
                byte[] bit = new byte[0];
                using (MemoryStream stream = new MemoryStream())
                {
                    encoder.Frames.Add(BitmapFrame.Create(bmpSrc));
                    encoder.Save(stream);
                    bit = stream.ToArray();
                    stream.Close();
                }
    
                return bit;
            }
