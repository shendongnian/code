    public static class NumberExtension
    {
        private static Dictionary<int, string> pointers = new Dictionary<int, string>();
        public static unsafe void SetValue(this Number source, string value)
        {
            if (pointers.ContainsKey((int)&source))
                pointers[(int)&source] = value;
            else
                pointers.Add((int)&source, value);
        }
        public static unsafe string GetValue(this Number source)
        {
            if (pointers.ContainsKey((int)&source))
                return pointers[(int)&source];
            return source.ToString();
        }
    }
