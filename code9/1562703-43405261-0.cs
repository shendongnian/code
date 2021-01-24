            bmp.Save(stream, ImageFormat.Jpeg);
        }
        else
        {
            image.Save(stream, ImageFormat.Jpeg);
        }
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
