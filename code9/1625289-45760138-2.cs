    // test to make sure it works
    static void Main(string[] args) {
        var bytes = new byte[] { 10, 12, 200, 255, 0 };
        var bits = new BitArray(bytes);
        var newBytes = ConvertToByte(bits);
        if (bytes.SequenceEqual(newBytes))
            Console.WriteLine("Successfully converted byte[] to bits and then back to byte[]");
        else
            Console.WriteLine("Conversion Problem");
    }
    static byte[] ConvertToByte(BitArray bits) {
        var bytes = new byte[(bits.Length - 1) / 8 + 1];
        bits.CopyTo(bytes, 0);
        return bytes;
    }
