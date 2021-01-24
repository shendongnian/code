    public static byte[] ConvertImageToByte(Image Value)
    {
        if (Value != null)
        {
            MemoryStream fs = new MemoryStream();
            ((Bitmap)Value).Save(fs, ImageFormat.Jpeg);          
            byte[] retval= fs.ToArray(); 
            fs.Dispose();
            return retval;
        }
        return null;
    }
