    /// <summary>
    /// Converts an array of bytes to a BitArray instance, 
    /// respecting the endian form of the operating system
    /// </summary>
    public static class BitArrayExtensions
    {
        public static BitArray ToBitArray(this byte[] bytes)
        {
            bool[] allbits = new bool[bytes.Length * 8];
            for (int b = 0; b < bytes.Length; b++)
            {
                bool[] bits = new bool[8];
                new BitArray(new byte[] { bytes[b] }).CopyTo(bits, 0);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bits);
                
                bits.CopyTo(allbits, b * 8);
            }
            return new BitArray(allbits);
        }
    }
