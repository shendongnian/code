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
    public Int64 GetPixelMaxValue(int valueIndex, Bitmap image)
    {
        var pixelFormat = new Dictionary<PixelFormat, PixelFormatData>
        {
            { PixelFormat.Format24bppRgb, new PixelFormatData(3, 3) },
            { PixelFormat.Format48bppRgb, new PixelFormatData(3, 6) }
        };
        if (!pixelFormat.ContainsKey(image.PixelFormat))
            throw new ArgumentException(nameof(image.PixelFormat));
        Int64 highestValue = 0;
        var data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
        var pixelFormatData = pixelFormat[image.PixelFormat];
        var ptr = data.Scan0;
        for (int x = 0; x < image.Width * image.Height; x++)
        {
            int bytes = pixelFormatData.BytesPerPixel;
            byte[] bits = new byte[bytes];
            Marshal.Copy(ptr, bits, 0, bits.Length);
            ptr += bytes;
            var bytesPerValue = pixelFormatData.BytesPerPixel / pixelFormatData.ValueCount;
            var valueData = bits
                .Skip(bytesPerValue * valueIndex)
                .Take(bytesPerValue)
                .ToList();
            while(valueData.Count < 8)
                valueData.Add(0);
                
            var red = BitConverter.ToInt64(valueData.ToArray(), 0);
            if (highestValue < red)
                highestValue = red;
        }
        image.UnlockBits(data);
        return highestValue;
    }
