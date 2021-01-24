    public static class Volatile
    {
        public static bool Read(ref bool location)
        {
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }
        public static void Write(ref byte location, byte value)
        {
            Thread.MemoryBarrier();
            location = value;
        }
    }
