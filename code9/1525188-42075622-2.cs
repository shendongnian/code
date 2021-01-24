    static byte GetLowNybble(this byte input)
    {
        return input % 16;
    }
    static byte GetHighNybble(this byte input)
    {
        return input / 16;
    }
    var hiNybble = source.GetHighNybble();
    var loNybble = source.GetLowNybble();
