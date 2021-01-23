    class intFromBigEndianByteArray {
        public byte[] b;
        public int this[int i] {
            get {
                i <<= 2; // i *= 4; // optional
                return (int)b[i] << 24 | (int)b[i + 1] << 16 | (int)b[i + 2] << 8 | b[i + 3];
            }
            set {
                i <<= 2; // i *= 4; // optional
                b[i    ] = (byte)(value >> 24);
                b[i + 1] = (byte)(value >> 16);
                b[i + 2] = (byte)(value >>  8);
                b[i + 3] = (byte)value;
            }
        }
    }
