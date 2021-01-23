    public class DistanceBitmapLevenstein : IDistance<Bitmap>
    {
        public double Distance(Bitmap x, Bitmap y)
        {
            return Accord.Math.Distance.Levenshtein(ImageToByte(x), ImageToByte(y));
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
