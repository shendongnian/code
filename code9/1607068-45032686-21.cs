    public class PixelFormatData
    {
        // example => rgb are three values,
        //         => argb are four values
        public int ValueCount { get; set; }
        public int BitsPerPixel { get; set; }
        public PixelFormatData(int valueCount, int bitsPerPixel)
        {
            ValueCount = valueCount;
            BitsPerPixel = bitsPerPixel;
        }
    }
    public static readonly Dictionary<PixelFormat, PixelFormatData> PixelFormats = new Dictionary<PixelFormat, PixelFormatData>
    {
        { PixelFormat.Format24bppRgb, new PixelFormatData(3, 24) },
        { PixelFormat.Format48bppRgb, new PixelFormatData(3, 48) }
    };
    public static IEnumerable<byte[]> GetBytes(Bitmap image)
    {
        if (!PixelFormats.ContainsKey(image.PixelFormat))
            throw new ArgumentException(nameof(image.PixelFormat));
        var pixelFormatData = PixelFormats[image.PixelFormat];
        var imageData = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, image.PixelFormat);
        var ptr = imageData.Scan0;
        int bytesPerPixel = pixelFormatData.BitsPerPixel / 8,
            imageSize = image.Width * image.Height;
        for (int x = 0; x < imageSize; x++)
        {
            yield return ptr.CopyAndMove(bytesPerPixel);
        }
        image.UnlockBits(imageData);
    }
    public static IEnumerable<int> GetValues(Bitmap image, int valueIndex)
    {
        if (!PixelFormats.ContainsKey(image.PixelFormat))
            throw new ArgumentException(nameof(image.PixelFormat));
        var pixelFormatData = PixelFormats[image.PixelFormat];
        int bytesPerPixel = pixelFormatData.BitsPerPixel / 8,
            bytesPerValue = bytesPerPixel / pixelFormatData.ValueCount;
        return GetBytes(image)
            .Select(bytes =>
                bytes.Skip(bytesPerValue * valueIndex)
                     .Take(bytesPerValue)
                     .RightPad(4))
            .Select(valueData => BitConverter.ToInt32(valueData.ToArray(), 0));
    }
