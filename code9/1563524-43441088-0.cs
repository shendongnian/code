    public static partial class TextExtensions
    {
        static void ToBytesWithoutEncoding(char c, out byte lower, out byte upper)
        {
            var u = (uint)c;
            lower = unchecked((byte)u);
            upper = unchecked((byte)(u >> 8));
        }
        public static byte[] ToByteArrayWithoutEncoding(this char c)
        {
            byte lower, upper;
            ToBytesWithoutEncoding(c, out lower, out upper);
            return new byte[] { lower, upper };
        }
        public static byte[] ToByteArrayWithoutEncoding(this ICollection<char> list)
        {
            if (list == null)
                return null;
            var bytes = new byte[checked(list.Count * 2)];
            int to = 0;
            foreach (var c in list)
            {
                ToBytesWithoutEncoding(c, out bytes[to], out bytes[to + 1]);
                to += 2;
            }
            return bytes;
        }
        public static char ToCharWithoutEncoding(this byte[] bytes)
        {
            return bytes.ToCharWithoutEncoding(0);
        }
        public static char ToCharWithoutEncoding(this byte[] bytes, int position)
        {
            if (bytes == null)
                return default(char);
            char c = default(char);
            if (position < bytes.Length)
                c += (char)bytes[position];
            if (position + 1 < bytes.Length)
                c += (char)((uint)bytes[position + 1] << 8);
            return c;
        }
        public static List<char> ToCharListWithoutEncoding(this byte[] bytes)
        {
            if (bytes == null)
                return null;
            var chars = new List<char>(bytes.Length / 2 + bytes.Length % 2);
            for (int from = 0; from < bytes.Length; from += 2)
            {
                chars.Add(bytes.ToCharWithoutEncoding(from));
            }
            return chars;
        }
    }
