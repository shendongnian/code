    public static byte[] ConvertImageToByte(Image Value)
    {
        if (Value != null)
        {
            MemoryStream fs = new MemoryStream();
            ((Bitmap)Value).Save(fs, ImageFormat.Jpeg);
            //inf.Image = new byte[Convert.ToInt32(fs.Length)];
            byte[] retval= fs.ToArray(); 
            fs.Dispose();
            return retval;
        }
        return null;
    }
