    public static class EnumerableExtensions
    {
        public static List<T> RightPad<T>(this IEnumerable<T> collection, int total)
        {
            var list = collection.ToList();
            while (list.Count < 8)
                list.Add(default(T));
            return list;
        }
    }
    public static class IntPtrExtensions
    {
        public static byte[] CopyAndMove(this IntPtr ptr, int count)
        {
            byte[] bytes = new byte[count];
            Marshal.Copy(ptr, bytes, 0, count);
            ptr += count;
            return bytes;
        }
    }
