    public static class BaseN
    {
        private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";
        public static String Encode(long input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");
            var result = new System.Collections.Generic.Stack<char>();
            while (input != 0)
            {
                result.Push(CharList[(int)(input % CharList.Length)]);
                input /= CharList.Length;
            }
            return new string(result.ToArray());
        }
        public static long Decode(string input)
        {
            long result = 0, pos = 0;
            foreach (char c in input.Reverse())
            {
                result += CharList.IndexOf(c) * (long)Math.Pow(CharList.Length, pos);
                pos++;
            }
            return result;
        }
    }
