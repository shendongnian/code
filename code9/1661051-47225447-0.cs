    static class EnumerableExtensions
    {
        public static IEnumerable<Byte> ToBytes(this IEnumerable<Bool> bools)
        {
            // converts the bools sequence into Bytes with the same 8 bit
            // pattern as 8 booleans in the array; MSB first
            if (bools == null) throw new ArgumentNullException(nameof(bools));
            // while there are elements, take 8, and convert to Byte
            while (bools.Any())
            {
                IEnumerable<bool> eightBools = bools.Take(8);
                Byte convertedByte = eightBools.ToByte();
                yield return convertedByte();
                 // remove the eight bools; do next iteration
                 bools = bools.Skip(8);
            }
        }
        public static Byte ToByte(this IEnumerable<bool> bools)
        {    // converts the first 8 elements of the bools sequence
             // into one Byte with the same binary bit pattern
             // example: 00000011 = 3
             if (bools == null) throw new ArgumentNullException(nameof(bools));
             var boolsToConvert = bools.Take(8);
             
             // convert
             byte result = 0;
             int index = 8 - source.Length;
             foreach (bool b in boolsToConvert)
             {
                 if (b)
                     result |= (byte)(1 << (7 - index));
                 index++;
             }
             return result;
        }
    }
