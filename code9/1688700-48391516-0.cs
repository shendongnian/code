    public static bool GetBit(this byte data, byte position)
    {
        byte mask = (byte)(1 << position);
        return (data & mask) > 0;
    }
    public static byte SetBit(this byte data, byte position, bool value)
    {
        byte mask = (byte)(1 << position);
        if (value)
        {
            return (byte)(data | mask);
        }
        else
        {
            return (byte)( data & (~mask));
        }
    }
    static void Main(string[] args)
    {
        byte data = 0b0000100;
        if (data.GetBit(2))
        {
        }
        data = data.SetBit(4, true);
        data = data.SetBit(2, false);
    }
