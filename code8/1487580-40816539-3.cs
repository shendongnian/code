    static Bgra32Pixel[] CopyBytesWithPlain(byte[] data)
    {
        if (data.Length % 4 != 0) throw new ArgumentOutOfRangeException("data", "Data length must be divisable by 4 (struct size).");
    
        Bgra32Pixel[] returnData = new Bgra32Pixel[data.Length / 4];
    
        for (int i = 0; i < returnData.Length; i++)
            returnData[i] = new Bgra32Pixel()
            {
                B = data[i * 4 + 0],
                G = data[i * 4 + 1],
                R = data[i * 4 + 2],
                A = data[i * 4 + 3]
            };
        return returnData;
    }
    
    static Bgra32Pixel[] CopyBytesWithLinq(byte[] data)
    {
        if (data.Length % 4 != 0) throw new ArgumentOutOfRangeException("data", "Data length must be divisable by 4 (struct size).");
    
        return data
            .Select((b, i) => new { Byte = b, Index = i })
            .GroupBy(g => g.Index / 4)
            .Select(g => g.Select(b => b.Byte).ToArray())
            .Select(a => new Bgra32Pixel()
            {
                B = a[0],
                G = a[1],
                R = a[2],
                A = a[3]
            })
            .ToArray();
    }
