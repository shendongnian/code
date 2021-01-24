    using System.Drawing;
    public static byte[] ImageToByte(Image img)
    {
        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }
