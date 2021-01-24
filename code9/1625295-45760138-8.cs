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
