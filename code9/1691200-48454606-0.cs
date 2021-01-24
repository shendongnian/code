    public BigInteger GetPowerOfTwo(int pow)
    {
        BigInteger n = 1;
        while (pow > 0)
        {
            n = n * 2;
            pow--;
        }
        return n;
    }
    private byte[] RightPadWithByte(byte[] input, byte pad)
    {
        var newInput = new byte[16];
        for (var ii = 0; ii < 16; ii++)
        {
            if (ii < input.Length)
            {
                newInput[ii] = input[ii];
            }
            else
            {
                newInput[ii] = pad;
            }
        }
        return newInput;
    }
    public Guid MakeGuidFromBigInteger(BigInteger n)
    {
        var bytes = n.ToByteArray();
        byte pad;
        if (n < 1)
        {
            pad = 0xff;
        }
        else
        {
            pad = 0x00;
        }
        var paddedBytes = RightPadWithByte(bytes, pad);
        var guid = new Guid(paddedBytes);
        return guid;
    }
    public BigInteger GuidToBigInteger(Guid guid)
    {
        byte[] guidAsBytes = guid.ToByteArray();
        BigInteger bigInteger = new BigInteger(guidAsBytes);
        return bigInteger;
    }
