        public static byte[] DoWork()
        {
            var buffer = new byte[10];
            using (var stream = new MemoryStream())
            {
                for (int i = 0; i < 10; i++)
                {
                    stream.Write(buffer, i, 1);
                }
                return stream.ToArray();
            }
        }
        public static async Task<byte[]> DoWorkAsync()
        {
            var buffer = new byte[10];
            using (var stream = new MemoryStream())
            {
                for (int i = 0; i < 10; i++)
                {
                    await stream.WriteAsync(buffer, i, 1);
                }
                return stream.ToArray();
            }
        }
