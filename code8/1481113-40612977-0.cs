    public BigInteger StartInteger { get; private set; }
    [ProtoMember(11002, DataFormat = DataFormat.FixedSize)]
    private byte[] StartIntegerSerialized
    {
        get { return StartInteger.ToByteArray(); }
        set { StartInteger = new BigInteger(value); }
    }
