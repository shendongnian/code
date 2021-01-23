    public static byte[] ImageToByte(Image pImage)
    {
     ImageConverter tmpConverter = new ImageConverter();
     return (byte[])tmpConverter.ConvertTo(pImage, typeof(byte[]));
    }
