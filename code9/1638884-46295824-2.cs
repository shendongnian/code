    public static class RandomExt
    {
        public static long NextLong(this Random self, long min, long max)
        {
            // Get a random 64 bit number.
            var buf = new byte[sizeof(ulong)];
            self.NextBytes(buf);
            ulong n = BitConverter.ToUInt64(buf, 0);
            // Scale to between 0 inclusive and 1 exclusive; i.e. [0,1).
            double normalised = n / (ulong.MaxValue + 1.0);
            // Determine result by scaling range and adding minimum.
            double range = (double)max - min;
            return (long)(normalised * range) + min;
        }
        public static ulong NextULong(this Random self, ulong min, ulong max)
        {
            // Get a random 64 bit number.
            var buf = new byte[sizeof(ulong)];
            self.NextBytes(buf);
            ulong n = BitConverter.ToUInt64(buf, 0);
            // Scale to between 0 inclusive and 1 exclusive; i.e. [0,1).
            double normalised = n / (ulong.MaxValue + 1.0);
            // Determine result by scaling range and adding minimum.
            double range = (double)max - min;
            return (ulong)(normalised * range) + min;
        }
    }
