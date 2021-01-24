    static long Pack(long a24, long b16, long c24) {
        // a24 can go with no masking, because its MSB becomes
        // the MSB of the 64-bit number. The other two numbers
        // need to be truncated to deal with 1s in the upper bits of negatives.
        return a24<<40 | (b16&0xffffL)<<24 | (c24&0xffffffL);
    }
    static void Unpack(long packed, out int a24, out int b16, out int c24) {
        a24 = (int)(packed >> 40); // Sign extension is done in the long
        b16 = ((int)(packed >> 8)) >> 16; // Sign extension is done in the int
        c24 = ((int)(packed << 8)) >> 8;  // Sign extension is done in the int
    }
