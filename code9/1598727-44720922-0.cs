    public class SafeRandom
    {
        public static SafeRandom Instance { get; private set; }
        public SafeRandom()
        {
            Instance = this;
        }
        [ThreadStatic]
        private RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        // Return a random integer between a min and max value.
        public int Next(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                provider.GetBytes(four_bytes);
                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }
            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                (scale / (double)uint.MaxValue));
        }
    }
