    private static void SaveJpeg(Image image, Stream target, int quality)
    {
        if (quality < 0)
            quality = 90; //90 is a very good default to stick with.
        if (quality > 100)
            quality = 100;
        using (EncoderParameters p = new EncoderParameters(1))
        {
            using (EncoderParameter ep = new EncoderParameter(Encoder.Quality, quality))
            {
                p.Param[0] = ep;
                ImageCodecInfo info = ImageResizer.Plugins.Basic.DefaultEncoder.GetImageCodeInfo("image/jpeg");
                if (!target.CanSeek)
                {
                    using (MemoryStream ms = new MemoryStream(_streamCopyBuffer))
                    {
                        image.Save(ms, info, p);
                        ms.WriteTo(target);
                    }
                }
                else
                {
                    image.Save(target, info, p);
                }
            }
        }
    }
