    static void Main(string[] args)
    {
        var guid = new Guid("bdc39e63-5947-4704-9e12-ec66c8773742");
        Console.WriteLine(guid);
        var numbers = FindNumbersFromGuid(guid, 900, 5);
        
        Console.WriteLine("Numbers: ");
        foreach (var elem in numbers)
        {
            Console.WriteLine(elem);
        }
        Console.ReadKey();
    }
    private static int[] FindNumbersFromGuid(Guid input, int maxNumber, int numberCount)
    {
        var output = new int[numberCount];
        var maxBits = MaxBits(maxNumber);
        var bytes = input.ToByteArray();
        for (int i = 0, bitCount = 0; i < numberCount; i++)
        {
            int acc = 0;
            var limit = bitCount + maxBits;
            for (int j = bitCount; j < limit; j++)
            {
                acc = acc + (GetBit(bytes, j) << (j - bitCount));
            }
            bitCount += maxBits;
            output[i] = acc % maxNumber;
        }
        return output;
    }
    private static int GetBit(byte[] bytes, int i)
    {
        return (bytes[i / 8] >> i % 8) & 1;
    }
    private static int MaxBits(int number)
    {
        var bits = 1;
        var acc = 1;
        while (number > acc)
        {
            bits++;
            acc <<= 1;
        }
        return bits;
    }
