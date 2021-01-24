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
    public int GetPixelMaxValue(int valueIndex, Bitmap image)
    {
        if (!PixelFormats.ContainsKey(image.PixelFormat))
            throw new ArgumentException(nameof(image.PixelFormat));
            
        var pixelFormatData = PixelFormats[image.PixelFormat];
        var imageData = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, image.PixelFormat);
        var ptr = imageData.Scan0;
        int highestValue = 0,
            bytesPerPixel = pixelFormatData.BitsPerPixel / 8,
            bytesPerValue = bytesPerPixel / pixelFormatData.ValueCount,
            imageSize = image.Width * image.Height;
        for (int x = 0; x < imageSize; x++)
        {
            byte[] gbrBytes = ptr.CopyAndMove(bytesPerPixel);
                
            var valueData = gbrBytes
                .Skip(bytesPerValue * valueIndex)
                .Take(bytesPerValue)
                .RightPad(4);
            var value = BitConverter.ToInt32(valueData.ToArray(), 0);
            highestValue = Math.Max(highestValue, value);
        }
        image.UnlockBits(imageData);
        return highestValue;
    }
