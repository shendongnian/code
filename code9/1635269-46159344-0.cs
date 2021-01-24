    public static byte[] AddCrc(this byte[] input) //type param not used.
    {
        if (input == null) throw new ArgumentNullException("input");
        var crc = makeCrc2bytes(input, input.Length);
        var result = new byte[input.Length + crc.Length];
        Array.Copy(input, 0, result, 0, input.Length);
        Array.Copy(crc, 0, result, input.Length, crc.Length);
        return result;
    }
    
