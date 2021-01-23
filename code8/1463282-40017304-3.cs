    public byte Checksum(params byte[] val)
    {
        if (val == null)
            throw new ArgumentNullException("val");
        byte c = 0;
        foreach (byte b in val)
        {
            c = table[c ^ b];
        }
        return c;
    }
