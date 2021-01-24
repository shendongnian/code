    using System;
    using System.Linq;
    
    static class Program
    {
        static string AsBinary(int val) => Convert.ToString(val, 2).PadLeft(11, '0');
        static string AsBinary(byte val) => Convert.ToString(val, 2).PadLeft(8, '0');
        static void Main()
        {
            int[] source = new int[1432];
            var rand = new Random(123456);
            for (int i = 0; i < source.Length; i++)
                source[i] = rand.Next(0, 2047); // 11 bits
    
            // Console.WriteLine(string.Join(" ", source.Take(5).Select(AsBinary)));
            
    
            var raw = Encode(source);
            // Console.WriteLine(string.Join(" ", raw.Take(6).Select(AsBinary)));
            var clone = Decode(raw);
    
            // now prove that it worked OK
            if (source.Length != clone.Length)
            {
                Console.WriteLine($"Length: {source.Length} vs {clone.Length}");
            }
            else
            {
                int failCount = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] != clone[i] && failCount++ == 0)
                    {
                        Console.WriteLine($"{i}: {source[i]} vs {clone[i]}");
                    }
                }
                Console.WriteLine($"Errors: {failCount}");
            }
        }
        static byte[] Encode(int[] source)
        {
            long bits = source.Length * 11;
            int len = (int)(bits / 8);
            if ((bits % 8) != 0) len++;
    
            byte[] arr = new byte[len];
            int bitOffset = 0, index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                // note: this encodes little-endian
                int val = source[i] & 2047;
                int bitsLeft = 11;
                if(bitOffset != 0)
                {
                    val = val << bitOffset;
                    arr[index++] |= (byte)val;
                    bitsLeft -= (8 - bitOffset);
                    val >>= 8;
                }
    
                if(bitsLeft >= 8)
                {
                    arr[index++] = (byte)val;
                    bitsLeft -= 8;
                    val >>= 8;
                }
                if(bitsLeft != 0)
                {
                    arr[index] = (byte)val;
                }
                bitOffset = bitsLeft;
            }
            return arr;
        }
    
        private static int[] Decode(byte[] source)
        {
            int bits = source.Length * 8;
            int len = (int)(bits / 11);
            // note no need to worry about remaining chunks - no ambiguity since 11 > 8
    
            int[] arr = new int[len];
            int bitOffset = 0, index = 0;
            for(int i = 0; i < source.Length; i++)
            {
                int val = source[i] << bitOffset;
                int bitsLeftInVal = 11 - bitOffset;
                if(bitsLeftInVal > 8)
                {
                    arr[index] |= val;
                    bitOffset += 8;
                }
                else if(bitsLeftInVal == 8)
                {
                    arr[index++] |= val;
                    bitOffset = 0;
                }
                else
                {
                    arr[index++] |= (val & 2047);
                    arr[index] = val >> 11;
                    bitOffset = 8 - bitsLeftInVal;
                }
            }
            return arr;
    
        }
    }
    
