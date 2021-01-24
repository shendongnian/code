    public class PixelFormatData
    {
        // example => rgb are three values
        public int ValueCount { get; set; }
        public int BytesPerPixel { get; set; }
        public PixelFormatData(int valueCount, int bytesPerPixel)
        {
            ValueCount = valueCount;
            BytesPerPixel = bytesPerPixel;
        }
    }
    public static readonly Dictionary<PixelFormat, PixelFormatData> PixelFormats = new Dictionary<PixelFormat, PixelFormatData>
    {
        { PixelFormat.Format24bppRgb, new PixelFormatData(3, 3) },
        { PixelFormat.Format48bppRgb, new PixelFormatData(3, 6) }
    };
    public Int64 GetPixelMaxValue(int valueIndex, Bitmap image)
    {
        if (!PixelFormats.ContainsKey(image.PixelFormat))
            throw new ArgumentException(nameof(image.PixelFormat));
        Int64 highestValue = 0;
        var data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
        var pixelFormatData = PixelFormats[image.PixelFormat];
        var ptr = data.Scan0;
        var bytesPerValue = pixelFormatData.BytesPerPixel / pixelFormatData.ValueCount;
        var imageSize = image.Width * image.Height;
        for (int x = 0; x < imageSize; x++)
        {
            byte[] bits = new byte[pixelFormatData.BytesPerPixel];
            Marshal.Copy(ptr, bits, 0, bits.Length);
            ptr += pixelFormatData.BytesPerPixel;
            var valueData = bits
                .Skip(bytesPerValue * valueIndex)
                .Take(bytesPerValue)
                .ToList();
            while (valueData.Count < 8)
                valueData.Add(0);
            var value = BitConverter.ToInt64(valueData.ToArray(), 0);
            if (highestValue < value)
                highestValue = value;
        }
        image.UnlockBits(data);
        return highestValue;
    }
