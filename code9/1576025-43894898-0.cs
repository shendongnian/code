    private static System.Numerics.BigInteger GetBigInteger(byte[] parameter)
    {
        byte[] signPadded = new byte[parameter.Length + 1];
        Buffer.BlockCopy(parameter, 0, signPadded, 1, parameter.Length);
        Array.Reverse(signPadded);
        return new System.Numerics.BigInteger(signPadded);
    }
