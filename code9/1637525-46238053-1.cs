    [BitFieldNumberOfBitsAttribute(8)]
    struct ExampleBitField : IBitField
    {
    [BitFieldInfo(0, 1)]
    public bool Bit1 { get; set; }
    [BitFieldInfo(1, 1)]
    public byte Bit2 { get; set; }
    [BitFieldInfo(2, 2)]
    public byte TwoBits { get; set; }
    [BitFieldInfo(4, 4)]
    public byte FourBits { get; set; }
    }
