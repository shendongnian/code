    const double scale = 4.6566128752458E-10;
    double prev = 0;
    Dictionary<long, int> hist = new Dictionary<long, int>();
    for (int i = 0; i < int.MaxValue; i++)
    {
        long bits = BitConverter.DoubleToInt64Bits(i * scale - prev);
        if (!hist.ContainsKey(bits))
            hist[bits] = 1;
        else
            hist[bits]++;
        prev = i * scale;
        if ((i & 0xFFFFFF) == 0)
            Console.WriteLine("{0:0.00}%", 100.0 * i / int.MaxValue);
    }
