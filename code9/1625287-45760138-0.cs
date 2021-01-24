    // test to make sure it works
    static void Main(string[] args) {
        var bytes = new byte[] { 10, 12 };
        var bits = new BitArray(bytes);
        var newBytes = ConvertToByte(bits);
        if (bytes.Length != newBytes.Length) {
            Console.WriteLine("Conversion Problem");
            return;
        }
        for (int i = 0; i < bytes.Length; ++i)
            if (bytes[i] != newBytes[i]) {
                Console.WriteLine("Conversion Problem");
                return;
            }
        Console.WriteLine("Successfully converted byte[] to BitArray and then back to byte[]");
    }
    static byte[] ConvertToByte(BitArray bits) {
        var bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
        bits.CopyTo(bytes, 0);
        return bytes;
    }
