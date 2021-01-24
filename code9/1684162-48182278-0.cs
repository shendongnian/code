    public static byte[] Convert(Bitmap bmp)
    {
        var size = bmp.Width * bmp.Height / 8;
        var buffer = new byte[size];
        var i = 0;
        for (var y = 0; y < bmp.Height; y++)
        {
            for (var x = 0; x < bmp.Width; x++)
            {
                var color = bmp.GetPixel(x, y);
                if (color.B != 255 || color.G != 255|| color.R != 255)
                {
                    var pos = i / 8;
                    var bitInByteIndex = x % 8;
                    buffer[pos] |= (byte)(1 << 7 - bitInByteIndex);
                }
                i++;
            }
        }
        return buffer;
    }
