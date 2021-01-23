    public static uint bitRotate(uint x)
    {
        const int bits = 16;
        return (x << bits) | (x >> (32 - bits));
    }
    
    public static UInt32 Generate(int seed1, int seed2, int seed3)
    {
        // simple "hashing" algorithm
        UInt32 num = 1;
        for (uint i = 0; i < 16; i++)
        {
            // multiply by prime numbers
            num = num * 119 + (uint)seed1;
            num = bitRotate(num);
            num = num * 541 + (uint)seed2;
            num = bitRotate(num);
            num = num * 809 + (uint)seed3;
            num = bitRotate(num);
            num = num * 673 + (uint)i; // not sure if necessary
            num = bitRotate(num);
        }
        return num;
    }
