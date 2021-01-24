    static long Pack(long a24, long b16, long c24) {
        return a24<<40 | b16<<24 | c24;
    }
    static void Unpack(long packed, out int a24, out int b16, out int c24) {
        a24 = (int)(packed >> 40); // Sign extension is done in the long
        b16 = ((int)(packed >> 8)) >> 16; // Sign extension is done in the int
        c24 = ((int)(packed << 8)) >> 8;  // Sign extension is done in the int
    }
