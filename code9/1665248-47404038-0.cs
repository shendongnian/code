        public static ImageType CheckImageType(string path)
        {
            byte[] buf = new byte[2];
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int i = sr.BaseStream.Read(buf, 0, buf.Length);
                    if (i != buf.Length)
                    {
                        return ImageType.None;
                    }
                }
            }
            catch (Exception exc)
            {
                //Debug.Print(exc.ToString());
                return ImageType.None;
            }
            return CheckImageType(buf);
        }
        public static ImageType CheckImageType(byte[] buf)
        {
            if (buf == null || buf.Length < 2)
            {
                return ImageType.None;
            }
            int key = (buf[1] << 8) + buf[0];
            ImageType s;  
            if (_imageTag.TryGetValue(key, out s))
            {
                return s;
            }  
            return ImageType.None;
        }
    public enum ImageType
    {
        None = 0,
        BMP = 0x4D42,
        JPG = 0xD8FF,
        GIF = 0x4947,
        PCX = 0x050A,
        PNG = 0x5089,
        PSD = 0x4238,
        RAS = 0xA659,
        SGI = 0xDA01,
        TIFF = 0x4949
    }
